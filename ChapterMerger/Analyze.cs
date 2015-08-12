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
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using ChapterMergerForm;

namespace ChapterMerger
{
  public class Analyze
  {

    public int progressArg { get; set;}
    public int progressList { get; set; }

    private int progress = 1;
    private int processPercent = 0;

    public static System.ComponentModel.BackgroundWorker backgroundWorker;
    public bool hasOrdered = false;

    public List<string> orderedGroups = new List<string>();
    public List<FileObjectCollection> fileLists = new List<FileObjectCollection>();


    public Analyze()
    {

    }

  /// <summary>
  /// Use a BackgroundWorker object to report progress.
  /// </summary>
  /// <param name="backgroundWorker"></param>
    public Analyze(System.ComponentModel.BackgroundWorker backgroundWorker)
    {
      Analyze.backgroundWorker = backgroundWorker;
    }


  /// <summary>
  /// Main program - determines arguments if they need to be processed as a list or not for File Object creations
  /// </summary>
  /// <param name="argument"></param>
    public void process(string[] argument)
    {
      
      
      bool bIsDirectory;
      string fullpath;

      //FileObjectCollection fileList = new FileObjectCollection();
      ListProcessor processList = new ListProcessor();
      List<string> argList = new List<string>();
      

      foreach (string arg in argument)
      {
        /*
         * Temporary workaround for empty strings
         * For now, it should be "safe" for arguments passed from the GUI.
         * arguments normally should not contain empty strings
         * 
         */
        if (string.IsNullOrEmpty(arg))
        {
          //FileObject file = new FileObject(arg);
          fullpath = Path.GetFullPath(arg);

          //Initiliaze attribute checker
          FileAttributes attr = File.GetAttributes(fullpath);

          //Determine if provided path is a directory or a file
          if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            bIsDirectory = true;
          else
            bIsDirectory = false;

          //If it's a file, add it to a fileList, if not, process it as a fileList
          if (bIsDirectory == false)
          {
            /*
             * Legacy code - no need for an extra FileObjectCollection
             * 
            FileObject file = new FileObject(arg);

            //Diagnostic purposes only.
            if (Config.Configure.diagnose >= 30)
            {
              Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}",
                file.extension,
                file.filename,
                file.filenameNoExtension,
                file.root,
                file.fullpath);
            }

            fileList.addFile(file);
             * */
            argList.Add(arg);
          }
          else
          {

          //Update percentage of the arguments processed. Used for GUI.

            processPercent = progress.ToPercentage(argument.Length);

            this.progressArg = processPercent;

            ProgressState progressState = new ProgressState();

            progressState.progressPercent = 0;

            Analyze.backgroundWorker.ReportProgress(progressArg, progressState);

            string[] s = Directory.GetFiles(fullpath, "*.mkv");
            processList.processList(s.ToList(), Path.GetFileNameWithoutExtension(arg), this, fullpath, argument.Length);

            progress++;

          }

        }
        
      }

    //for individual files: process the built list after foreach loop
      if (argList.Count > 1)
      {

        processPercent = 100;

        progressArg = processPercent;

        ProgressState progressState = new ProgressState();

        progressState.progressPercent = 0;

        Analyze.backgroundWorker.ReportProgress(progressArg, progressState);

        processList.processList(argList, "various files", this, Program.thisProgramPath);

      }

    }
    
  /// <summary>
  /// Launches the stored output paths in explorer, after merge creation
  /// </summary>
  /// <param name="selectFile">If true, add an explorer argument that selects a designated file.</param>
  /// <param name="argument">If set, open in explorer the supplied argument instead.</param>
    public void LaunchInExplorer(bool selectFile = false, string argument = null)
    {
      if (argument == null)
      {
        foreach (string outputPath in orderedGroups)
        {
          if (selectFile)
            Process.Start("explorer.exe", string.Format("/select,\"{0}\"", outputPath));
          else
            Process.Start("explorer.exe", outputPath + "\\output");
        }
      }
      else
      {
        if (selectFile)
          Process.Start("explorer.exe", string.Format("/select,\"{0}\"", argument));
        else
          Process.Start("explorer.exe", argument + "\\output");
      }
      
    }

  /// <summary>
  /// Deprecated - Execute the scripts using the paths stored by MakeFile.
  /// </summary>
    public void ExecuteScript()
    {
      foreach (string outputPath in orderedGroups)
      {
        Process process = Process.Start(outputPath);
        process.WaitForExit();
      }
    }

  }

}
