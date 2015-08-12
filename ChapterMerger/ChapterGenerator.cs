/*
 * 
This file is part of the ChapterMerger project
Copyright (C) 2015 Mon C.A.S.

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License along
with this program; if not, write to the Free Software Foundation, Inc.,
51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ChapterMerger
{
  class ChapterGenerator
  {

  /// <summary>
  /// Adds chapter fields to File Objects.
  /// </summary>
  /// <param name="file">The FileObject processed by InfoDump.</param>
  /// <returns></returns>
    public FileObject chapterDump(FileObject file)
    {
      int chapterNum = 0;
      string timeStart = "";
      string timeEnd = "";
      string chsuid = "";

      MatchCollection matches = Regex.Matches(file.mkvInfo, @"\|  \+ ChapterAtom\r*\n((\|   .*\r*\n)*)");

      Match fSuid = Regex.Match(file.mkvInfo, @"\| \+ Segment UID: (0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+)");

      file.suid = fSuid.Groups[1].Value;

      foreach (Match match in matches)
      {


        Match mTimeStart = Regex.Match(match.Value, @"\|   \+ ChapterTimeStart: (\d\d:\d\d:\d\d\.\d{8})");
        Match mTimeEnd = Regex.Match(match.Value, @"\|   \+ ChapterTimeEnd: (\d\d:\d\d:\d\d\.\d{8})"); ;
        Match mSuid = Regex.Match(match.Value, @"\|   \+ ChapterSegmentUID:.* (0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+ 0x\w+)"); ;


        timeStart = mTimeStart.Groups[1].Value;
        timeEnd = mTimeEnd.Groups[1].Value;
        chsuid = mSuid.Groups[1].Value;

        if (Config.Configure.includeChapterInfoOnFiles)
          file.addChapter(chapterNum, timeStart, timeEnd, chsuid, match.Value);
        else
          file.addChapter(chapterNum, timeStart, timeEnd, chsuid);

        chapterNum++;

      }

      return file;
    }

  }
}
