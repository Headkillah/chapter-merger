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

  /// <summary>
  /// Creates/fetches chapter informations from valid media files.
  /// </summary>
  class ChapterGenerator
  {

  /// <summary>
  /// Adds chapter fields to File Objects.
  /// </summary>
  /// <param name="file">The FileObject processed by InfoDumper.InfoDump.</param>
  /// <returns>The FileObjct with chapter fields.</returns>
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

    /// <summary>
    /// Adds media informations to FileObjects.
    /// </summary>
    /// <param name="file">The FileObject processed by InfoDumper.ffInfoDump.</param>
    /// <returns>The FileObject with processed media informations.</returns>
    public FileObject mediaDump(FileObject file)
    {

      List<string> tracklists = new List<string>();

      Match inputInfo = Regex.Match(file.ffInfo, @"Input #\d?, .*\r*\n([\s\S]*)(?:At least one.+)");

      file.mediaInfo.mediaStreams = new List<MediaStream>();

      file.mediaInfo.inputInfo = inputInfo.Value.Replace("\r","");
      file.mediaInfo.duration = Regex.Match(file.mediaInfo.inputInfo, @"  Duration\: (\d\d\:\d\d\:\d\d\.\d\d)(.*)").Groups[1].Value;
      file.mediaInfo.bitratekb = int.Parse(Regex.Match(file.mediaInfo.inputInfo, @"bitrate: (\d+) kb\/s").Groups[1].Value);

      MatchCollection streams = Regex.Matches(file.mediaInfo.inputInfo, @"    Stream #\d?\:\d?(?:(?:\S+)*)\: (.+)\: (.+)\r*\n((?:    Metadata:\r*\n(?:      .*)*)*)");

      foreach (Match stream in streams)
      {
        MediaStream mediastream = new MediaStream();

        mediastream.mediaType = (MediaType) Enum.Parse(typeof(MediaType), stream.Groups[1].Value, true);
        mediastream.codecInfo = stream.Groups[2].Value;
        mediastream.codec = stream.Groups[2].Value.Split(',')[0];
        mediastream.metaData = stream.Groups[3].Value;

        file.mediaInfo.mediaStreams.Add(mediastream);

      }

      if (!Config.Configure.includeMediaInfoOnFiles)
        file.mediaInfo.inputInfo = null;

      return file;
    }

    /// <summary>
    /// Deprecated. Adds media informations to FileObjects using FFprobe.
    /// </summary>
    /// <param name="file">The FileObject processed by InfoDumper.ffProbeDump.</param>
    /// <returns>The FileObject with processed media informations.</returns>
    public FileObject probeMediaDump(FileObject file)
    {

      List<string> tracklists = new List<string>();

      Match inputInfo = Regex.Match(file.ffInfo, @"Input #\d?, .*\r*\n([\s\S]*)");

      file.mediaInfo.mediaStreams = new List<MediaStream>();

      file.mediaInfo.inputInfo = file.ffInfo.Replace("\r", "");
      //file.mediaInfo.duration = Regex.Match(file.mediaInfo.inputInfo, @"  Duration\: (\d\d\:\d\d\:\d\d\.\d\d)(.*)").Groups[1].Value;
      //file.mediaInfo.bitratekb = int.Parse(Regex.Match(file.mediaInfo.inputInfo, @"bitrate: (\d+) kb\/s").Groups[1].Value);

      MatchCollection streams = Regex.Matches(file.mediaInfo.inputInfo, @"\[STREAM\]\n([\s\S]+?)\n\[.+STREAM\]");

      foreach (Match stream in streams)
      {
        MediaStream mediastream = new MediaStream();

        mediastream.mediaType = (MediaType)Enum.Parse(typeof(MediaType), Regex.Match(stream.Value, @"codec_type=(.*)").Groups[1].Value, true);
        mediastream.codecInfo = stream.Groups[1].Value;
        mediastream.codec = Regex.Match(stream.Value, @"codec_long_name=(.*)").Groups[1].Value;
        //mediastream.metaData = stream.Groups[3].Value;  //to be removed; metadata is no longer provided as is, as ffprobe is used.

        file.mediaInfo.mediaStreams.Add(mediastream);

      }

      return file;
    }

  }
}
