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

namespace ChapterMerger
{

  /// <summary>
  /// Analyzes arguments to construct file lists for processing for either Merge or Conversion.
  /// </summary>
  public partial class Analyze
  {

    /// <summary>
    /// Progress report in raw count of Arguments processed.
    /// </summary>
    public int progressArg { get; set;}

    /// <summary>
    /// Progress report in raw count of Lists processed.
    /// </summary>
    public int progressList { get; set; }

    /// <summary>
    /// The ProgressState that holds secondary progress reports.
    /// </summary>
    private ProgressState progressState = new ProgressState();

    /// <summary>
    /// Progress report in raw count.
    /// </summary>
    private int progress = 1;

    /// <summary>
    /// Progress report in percentage.
    /// </summary>
    private int processPercent = 0;

    /// <summary>
    /// The Global BackgroundWorker to send reports to.
    /// </summary>
    public static System.ComponentModel.BackgroundWorker backgroundWorker;

    /// <summary>
    /// Determines if the analyzed data has ordered chapter or not.
    /// </summary>
    public bool hasOrdered = false;

    /// <summary>
    /// Contains all the output folders for later reuse.
    /// </summary>
    public static List<string> outputGroups = new List<string>();
    
    /// <summary>
    /// Contains all FileObjectCollections that were processed and analyzed.
    /// </summary>
    public List<FileObjectCollection> fileLists = new List<FileObjectCollection>();

    public Analyze()
    {

    }

  /// <summary>
  /// Use a BackgroundWorker object to report progress.
  /// </summary>
  /// <param name="backgroundWorker">The Global BackgroundWorker to send reports to.</param>
    public Analyze(System.ComponentModel.BackgroundWorker backgroundWorker)
    {
      Analyze.backgroundWorker = backgroundWorker;
    }


  /// <summary>
  /// Main program - determines arguments if they need to be processed as a list or not for File Object creations
  /// </summary>
  /// <param name="argument">The arguments.</param>
    public void process(string[] argument)
    {
      
      
      bool bIsDirectory;
      string fullpath;

      ListProcessor processList = new ListProcessor();
      List<string> argList = new List<string>();

      List<string> filteredArgs = new List<string>();

      progressState.progressPercent = 0;
      

      foreach (string arg in argument)
      {
        /*
         * Temporary workaround for empty strings
         * For now, it should be "safe" for arguments passed from the GUI.
         * arguments normally should not contain empty strings
         * 
         */
        if (!string.IsNullOrEmpty(arg))
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
            argList.Add(arg);
            filteredArgs.Add(arg);
          }
          else
          {

          //Update percentage of the arguments processed. Used for GUI.

            processPercent = progress.ToPercentage(argument.Length);

            progressArg = processPercent;

            Analyze.backgroundWorker.ReportProgress(progressArg, progressState);

            List<string> folderFiles = new List<string>();

            foreach (string extension in MediaData.extensions)
              foreach (string folderFile in Directory.GetFiles(fullpath, "*" + extension))
              {
                folderFiles.Add(folderFile);
                filteredArgs.Add(folderFile);
              }

            processList.processList(folderFiles, Path.GetFileNameWithoutExtension(arg), this, fullpath, argument.Length);

            progress++;

          }

        }
        
      }

    //for individual files: process the built list after foreach loop
      if (argList.Count > 1)
      {

        processPercent = 100;

        progressArg = processPercent;

        Analyze.backgroundWorker.ReportProgress(progressArg, progressState);

        processList.processList(argList, "various files", this, Program.defaultPath);
        
      }


      if (filteredArgs.Count > 0)
      {
        //AnalyzeList(filteredArgs); 
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
        foreach (string outputPath in outputGroups)
        {
          if (selectFile)
            Process.Start("explorer.exe", string.Format("/select,\"{0}\"", outputPath));
          else
            Process.Start("explorer.exe", outputPath);
        }
      }
      else
      {
        if (selectFile)
          Process.Start("explorer.exe", string.Format("/select,\"{0}\"", argument));
        else
          Process.Start("explorer.exe", argument);
      }
      
    }

  /// <summary>
  /// Deprecated - Execute the scripts using the paths stored by MakeFile.
  /// </summary>
    public void ExecuteScript()
    {
      foreach (string outputPath in outputGroups)
      {
        Process process = Process.Start(outputPath);
        process.WaitForExit();
      }
    }

  }

}
