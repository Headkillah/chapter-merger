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
using System.IO;

namespace ChapterMerger
{
  //TrackLister Object: object that spews out arranged track list for every file object it receives
  class TrackLister
  {
    //private int progress = 1;
    //private int processPercent = 0;

    public TrackLister()
    {

    }

    /// <summary>
    /// Rearranges chapter tracks to include the inserted external file determined by SUID.
    /// Also determines MergeArguments order.
    /// </summary>
    /// <param name="fileList">The FileObjectCollection processed by ChapterGenerator.</param>
    /// <param name="suid">The SuidLister that contains all SUIDs.</param>
    /// <param name="processor">The Analyze object for progression report.</param>
    /// <returns>The FileObjectCollection with FileObjects that has rearranged chapter tracks.</returns>
    public FileObjectCollection arrangeTrack(FileObjectCollection fileList, SuidLister suid, Analyze processor)
    {

      //string mergeargument = "";

      foreach (FileObject file in fileList.fileList)
      {

        int count = 0;
        string tempFileName = "";
        string tempFullPath = "";


      //First loop to determine which chapters have external suid attached
        foreach (ChapterAtom chaptera in file.chapterAtom)
        {
          foreach (Suid suidi in suid.suidList)
          {

            if (suidi.suid == chaptera.suid)
            {
              chaptera.suidFileName = suidi.fileName;
              chaptera.suidFullPath = suidi.fullPath;

              //Console.WriteLine("SUID match.");
            }

          }

          //mergeargument = mergeargument + chaptera.timeStart + chaptera.timeEnd + chaptera.suidFileName;
        }


      //Second loop that uses index to properly determine which chapter needs to be added as a MergeArgument
        for (int i = 0; i < file.chapterAtom.Count; i++)
        {

          var current = file.chapterAtom[i];

          var previous = current;
          var next = current;

          if (i > 0)
          {
            previous = file.chapterAtom.ElementAt(i - 1);
          }

          if (i < (file.chapterAtom.Count - 1))
          {
            next = file.chapterAtom.ElementAt(i + 1);
          }

          /*
           * Diagnostic purposes only
           * 
           * Console.WriteLine("Arrange Track");
           * Console.WriteLine("Current: " + current.suidFileName);
           * Console.WriteLine("Previous: " + previous.suidFileName);
           * Console.WriteLine("Next: " + next.suidFileName);
           * Console.WriteLine("\n");
           * */

      //The following routine should correctly determine when to split the the chapters optimally to insert the external SUID file
          if (current.suidFileName != null)
          {
            file.addMergeArg(current.suidFullPath, current.chapterNum, true);
            if (!file.shouldJoin)
              file.shouldJoin = true;
            if (!fileList.hasOrdered)
              fileList.hasOrdered = true;
            if (!processor.hasOrdered)
              processor.hasOrdered = true;
          }
          else
          {
            
            string timeCode = "";

          //TimeEnd Split Mode
            if (Config.Configure.splitModeTimeEnd && (next.suidFileName != null || i == file.chapterAtom.Count - 1))
            {
              count++;

              file.splitCount = count;

              timeCode = current.timeEnd;

            //to change, should dynamically change digit format to "ddd"
            // done
              tempFileName = Config.Configure.tempfileprefix + file.filenameNoExtension + Config.Configure.tempfilesuffix + "-" + count.ToString("D3") + ".mkv";
              tempFullPath = Path.Combine(fileList.folderPath, Config.Configure.tempfileprefix + file.filenameNoExtension + Config.Configure.tempfilesuffix) + "-" + count.ToString("D3") + ".mkv";

              file.addMergeArg(tempFullPath, current.chapterNum, false, timeCode, tempFileName, file.fullpath);
              if (i != file.chapterAtom.Count - 1) 
                file.addTimeCode(timeCode);
              file.addDelArg(tempFullPath, tempFileName);
            }
          //TimeStart Split Mode
            else if (Config.Configure.splitModeTimeStart && (previous.suidFileName != null || i == 0))
            {
              count++;

              file.splitCount = count;

              timeCode = current.timeStart;

              tempFileName = Config.Configure.tempfileprefix + file.filenameNoExtension + Config.Configure.tempfilesuffix + "-" + count.ToString("D3") + ".mkv";
              tempFullPath = Path.Combine(fileList.folderPath, Config.Configure.tempfileprefix + file.filenameNoExtension + Config.Configure.tempfilesuffix) + "-" + count.ToString("D3") + ".mkv";

              file.addMergeArg(tempFullPath, current.chapterNum, false, timeCode, tempFileName, file.fullpath);
              if (i > 0)
                file.addTimeCode(timeCode);
              file.addDelArg(tempFullPath, tempFileName);

            }

          }

        }
      
      }

      return fileList;
    }

  }
}
