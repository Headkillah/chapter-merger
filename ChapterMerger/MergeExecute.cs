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
using System.Diagnostics;
using System.IO;
using ChapterMerger;

namespace ChapterMerger
{
  class MergeExecute
  {

    private System.ComponentModel.BackgroundWorker backgroundWorker;

    private int progress;
    private int processPercent;

    public MergeExecute()
    {

    }

    public MergeExecute(System.ComponentModel.BackgroundWorker backgroundWorker)
    {
      this.backgroundWorker = backgroundWorker;
    }

    /// <summary>
    /// Executes merge arguments after ListProcessor has done its job.
    /// </summary>
    /// <param name="fileList">The FileObjectCollection processed by TrackLister.</param>
    /// <param name="processor">The Analyze object for progress reporting.</param>
    /// <param name="useCmd">Deprecated - sets whether to use cmd or not for merge execution.</param>
    /// <param name="fileListPercent">The percentage of File Lists processed. Used for progress reporting.</param>
    public void mergeExecute(FileObjectCollection fileList, Analyze processor, bool useCmd = false, int fileListPercent = 100)
    {

      List<string> cmdCommand = new List<string>();
      string splitArgument = "";
      string mergeArgument = "";
      string outputPath = "";

      ProgressState progressState = new ProgressState();
      progressState.listName = fileList.name;

      progress = 1;
      processPercent = 0;

      if (fileList.hasOrdered)
      {
        Directory.CreateDirectory(Path.Combine(fileList.folderPath, "output"));
      }

      if (Config.Configure.sourceOutputFolder)
      {
        outputPath = fileList.folderPath;
      }
      else
      {
        outputPath = Program.defaultPath;
      }

      Directory.CreateDirectory(Path.Combine(outputPath, "output"));

      foreach (FileObject file in fileList.fileList)
      {

      //Routine after merging
      //Checks if current backgroundWorker operation is cancelled
      //Stops this program if true
        if (this.backgroundWorker.CancellationPending)
        {
          return;
        }

        List<string> timeCodeList = new List<string>();
        List<string> delArgumentList = new List<string>();
        List<string> mergeArgumentList = new List<string>();
        List<string> chapterInfo = new List<string>();

        progressState.fileName = file.filename;

        processPercent = progress.ToPercentage(fileList.fileList.Count);
        progressState.progressPercent = processPercent;

        progressState.progressDetail = "";
        this.backgroundWorker.ReportProgress(fileListPercent, progressState);

        

        /*
          * Main process
          * */
        if (file.mergeArgument.Count > 1)
        {

          foreach (MergeArgument merge in file.mergeArgument)
          {

            if (merge.isExternalSuid)
              mergeArgumentList.Add("\"" + merge.fullPath + "\"");
            else
            {
              if (file.splitCount > 1)
              {
                mergeArgumentList.Add("\"" + merge.fullPath + "\"");
              }
              else
                mergeArgumentList.Add("\"" + merge.originalFullPath + "\"");
                
            }

          }

          foreach (TimeCode time in file.timeCode)
          {
            timeCodeList.Add(time.timeCode);
          }

          foreach (DelArgument del in file.delArgument)
          {
            delArgumentList.Add("\"" + del.fullPath + "\"");
          }

          string[] timeCode = timeCodeList.ToArray();
          string[] delString = delArgumentList.ToArray();
          string[] mergeString = mergeArgumentList.ToArray();
          string[] chaptersInfo = chapterInfo.ToArray();

          string tempFileName = "\"" + Config.Configure.tempfileprefix + file.filenameNoExtension + Config.Configure.tempfilesuffix + ".mkv\"";
          string newFileName = "\"output\\" + Config.Configure.newfileprefix + file.filenameNoExtension + Config.Configure.newfilesuffix + ".mkv\"";
          string originalFileName = "\"" + file.fullpath + "\"";

          if (file.shouldJoin)
          {

            //processor.orderedGroups.Add(outputPath); //should be inside a check outside this loop, else it would add needless duplicates of outputPath


            if (file.splitCount > 1)
            {
              splitArgument = "--no-chapters --split timecodes:" + String.Join(",", timeCode) + " -o " + tempFileName + " " + originalFileName;

            }

            mergeArgument = "--no-chapters -o " + newFileName + " " + String.Join(" +", mergeString);

          }

          progressState.progressDetail = "Building merge arguments...";
          this.backgroundWorker.ReportProgress(fileListPercent, progressState);

        }

      //Routine after merge arguments
      //Checks if current backgroundWorker operation is cancelled
      //Stops this program if true
        if (this.backgroundWorker.CancellationPending)
        {
          return;
        }

        if (file.shouldJoin)
        {
          ProcessStartInfo mergeProcess = new ProcessStartInfo();

          mergeProcess.FileName = Program.mergeExe;
          mergeProcess.UseShellExecute = false;
          mergeProcess.CreateNoWindow = true;
          mergeProcess.WorkingDirectory = fileList.folderPath;
          mergeProcess.WindowStyle = ProcessWindowStyle.Hidden;
          //mergeProcess.RedirectStandardOutput = true;

          if (file.splitCount > 1)
          {
            progressState.progressDetail = "Splitting file...";
            this.backgroundWorker.ReportProgress(fileListPercent, progressState);

            mergeProcess.Arguments = splitArgument;

            using (Process process = Process.Start(mergeProcess))
            {
              process.WaitForExit();
            }

          }

        //Routine after splitting
        //Checks if current backgroundWorker operation is cancelled
        //Stops this program if true
          if (this.backgroundWorker.CancellationPending)
          {
            foreach (DelArgument del in file.delArgument)
              File.Delete(del.fullPath);

            return;
          }

          progressState.progressDetail = "Merging file...";
          this.backgroundWorker.ReportProgress(fileListPercent, progressState);

          mergeProcess.Arguments = mergeArgument;

          using (Process process = Process.Start(mergeProcess))
          {
            process.WaitForExit();
          }

          progressState.progressDetail = "Deleting temporary files...";
          this.backgroundWorker.ReportProgress(fileListPercent, progressState);

          foreach (DelArgument del in file.delArgument)
            File.Delete(del.fullPath);

        }

        progress++;

      }

      if (fileList.hasOrdered && !processor.orderedGroups.Contains(outputPath))
      {
        processor.orderedGroups.Add(outputPath + "\\output");
      }

    }

  }

}
