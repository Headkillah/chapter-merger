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
using System.Windows.Forms;

namespace ChapterMerger
{
  class ListProcessor
  {

    private int progress;
    private int processPercent;

  /// <summary>
  /// Processes files to create File Objects for the main tasks of this program.
  /// Every tasks are denoted on each comment lines inside the method.
  /// </summary>
  /// <param name="list">The list that contains the fullpaths of the actual files.</param>
  /// <param name="listname">Name for the FileObjectCollection to be created.</param>
  /// <param name="processor">The Analyze object for progression report.</param>
  /// <param name="path">The path used as a working directory merge commands.</param>
  /// <param name="totalArguments">Optional. For progress report. The total number of lists to process.</param>
    public void processList(List<string> list, string listname, Analyze processor, string path = "C:\\", int totalArguments = 0)
    {

      FileObjectCollection fileList = new FileObjectCollection();
      TrackLister tracklist = new TrackLister();
      MakeFile makeFile = new MakeFile();
      ChapterGenerator chapterGet = new ChapterGenerator();
      ProgressState progressState = new ProgressState();
      
      fileList.folderPath = path;
      fileList.name = listname;

      progressState.listName = fileList.name;

      progress = 1;
      processPercent = 0;

      foreach (string s in list)
      {

        FileObject file = new FileObject(s);

        processPercent = progress.ToPercentage(list.Count);
        progressState.progressPercent = processPercent;
        progressState.fileName = file.filename;
        Analyze.backgroundWorker.ReportProgress(processor.progressArg, progressState);

      //Routine after splitting
      //Checks if current backgroundWorker operation is cancelled
      //Stops this program if true
        if (Analyze.backgroundWorker.CancellationPending)
        {
          return;
        }

        try
        {
          file = InfoDumper.infoDump(file);
          if (Program.hasFFmpeg) file = InfoDumper.ffInfoDump(file);
        }
        catch (Exception ex)
        {
          MessageBox.Show("Error:\r\n\r\n" + ex.Message, "Error");
        }

        progressState.progressDetail = "Dumping MKV info...";

        Analyze.backgroundWorker.ReportProgress(processor.progressArg, progressState);
        
        file = chapterGet.chapterDump(file);
        if (!String.IsNullOrEmpty(file.ffInfo)) file = chapterGet.mediaDump(file);

        if (!Config.Configure.includeMkvInfoOnFiles)
          file.mkvInfo = null;

        if (!Config.Configure.includeMediaInfoOnFiles)
          file.ffInfo = null;

        fileList.addFile(file);

      //For Diagnoses purposes only
        if (Config.Configure.diagnose >= 30)
        {
          Console.WriteLine("Chapter Atom count: {0}\n", file.chapterAtom.Count, file.mkvInfo);

          foreach (ChapterAtom chapter in file.chapterAtom)
          {
            {
              Console.WriteLine("File name: {0}\nChapter Number: {2}\nTime Start: {3}\nTime End: {4}\nSuid: {5}\n",
                file.filename,
                chapter.chapterInfo,
                chapter.chapterNum,
                chapter.timeStart,
                chapter.timeEnd,
                chapter.suid);

            }

          }

        }

        progressState.progressDetail = "Getting chapters' info...";
        
        Analyze.backgroundWorker.ReportProgress(processor.progressArg, progressState);


        progress++;
      }


      SuidLister suidList = getSuid(fileList);

      progressState.progressDetail = "Creating SUID list...";
      Analyze.backgroundWorker.ReportProgress(processor.progressArg, progressState);

      fileList = tracklist.arrangeTrack(fileList, suidList, processor);

      progressState.progressDetail = "Arranging new tracklist for every file...";
      Analyze.backgroundWorker.ReportProgress(processor.progressArg, progressState);

    //For Diagnostic purposes only
      if (Config.Configure.diagnose >= 30)
      {
        foreach (Suid suid in suidList.suidList)
        {

          {
            Console.WriteLine("SUID filename: " + suid.fileName);
            Console.WriteLine("SUID: " + suid.suid);
            Console.WriteLine("\n");
          }
        }

        Console.WriteLine("fileList.fileList.Count: " + fileList.fileList.Count + "\n");

        foreach (FileObject file in fileList.fileList)
        {

          //Console.WriteLine("Merge Argument count: {0}\n", file.mergeArgument.Count);

          foreach (MergeArgument merge in file.mergeArgument)
          {

            Console.WriteLine("Merge Argument:\nFile name: {0}\nTime Code: {1}\nFile Argument: {2}\nChapter Number: {3}\n",
                file.filename,
                merge.timeCode,
                merge.fileName,
                merge.chapterNum);

          }

          foreach (TimeCode time in file.timeCode)
          {
            Console.WriteLine("Time Code Argument: {0}\n", time.timeCode);
          }

          foreach (DelArgument del in file.delArgument)
          {
            Console.WriteLine("Del Argument: {0}\n", del.fileName);
          }

        }
      }

      processor.fileLists.Add(fileList);

      if (Config.Configure.doMakeXml)
      {
        makeFile.makeFile(fileList, processor);

        progressState.progressDetail = "Dumping XML file...";
        Analyze.backgroundWorker.ReportProgress(processor.progressArg, progressState);
      }
      
      if (Config.Configure.doMakeScript)
      {
        makeFile.makeXML(fileList, processor);

        progressState.progressDetail = "Creating Merge Script...";
        Analyze.backgroundWorker.ReportProgress(processor.progressArg, progressState);
      }
        

    }

/// <summary>
/// Creates an SuidLister object and returns it for the calling program.
/// The SuidLister object that is created here can be reused.
/// </summary>
/// <param name="fileList">The FileObjectCollection processed by InfoDump.</param>
/// <returns>The SuidLister with the list of all SUIDs present.</returns>
    public static SuidLister getSuid(FileObjectCollection fileList)
    {

      SuidLister suidLister = new SuidLister();

      foreach (FileObject file in fileList.fileList)
      {

      //to change - actual suid;
      //string suids = "suid";
      // done

        suidLister.addSuid(file);

      }

    //returns suidLister object
      return suidLister;
    }

  }
}
