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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChapterMerger
{
  public partial class ProgressForm : Form
  {

    private string[] args;
    private bool doMakeXml = false;
    private bool doMerge = false;

    private int progress;
    private int processPercent;

    public ProgressForm()
    {
      InitializeComponent();

    }

  /// <summary>
  /// Gets the passed list of argument and analyzes it by using the Processor instance.
  /// </summary>
  /// <param name="args">A string array that includes all filelist view arguments.</param>
    public ProgressForm(string[] args)
    {
      this.args = args;

      InitializeComponent();
      
    }

  /// <summary>
  /// Custom constructor - sets doMerge
  /// </summary>
  /// <param name="doMerge">If true, calls the merge method, using the processed filelists in the main Processor instance.</param>
    public ProgressForm(bool doMerge)
    {
      this.doMerge = doMerge;
      InitializeComponent();
    }

  //Custom constructors - gets file lists to process
    public ProgressForm(string[] args, bool doMakeXml)
    {
      this.args = args;
      this.doMakeXml = doMakeXml;

      InitializeComponent();

    }

  //ProgressForm OnLoad
    private void ProgressForm_Load(object sender, EventArgs e)
    {
      if (doMerge)
      {
        backgroundWorker3.RunWorkerAsync();
      } else
        backgroundWorker1.RunWorkerAsync();
    }

  //BackgroundWorker - Main process for files
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      Analyze process = new Analyze(backgroundWorker1);

      MainWindow.projectManager.analyze = process;

      process.process(args);

      if (backgroundWorker1.CancellationPending)
      {
        e.Cancel = true;
        return;
      }

      e.Result = process;

    }

    private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      ProgressState progressState = e.UserState as ProgressState;
      progressBar1.Value = e.ProgressPercentage;
      progressBar2.Value = progressState.progressPercent;

      this.Text = "Processing " + e.ProgressPercentage.ToString() + "%...";
      this.label1.Text = "Processing "  + progressState.listName.TruncateLast(60) + " (" + e.ProgressPercentage.ToString() + "%)...";
      
      this.label2.Text = "Processing " + progressState.fileName.TruncateLast(60) + " (" + progressState.progressPercent.ToString() + "%)";
      this.detailLabel.Text = progressState.progressDetail;
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {

      if (e.Cancelled)
      {
        MessageBox.Show("Processing cancelled.");
      }
      else 
      {
        Analyze processor = e.Result as Analyze;
        DialogResult result = new DialogResult();

        if (processor.hasOrdered)
        {
          if (!Config.Configure.executeScriptAfter)
          {
            if (Config.Configure.doMakeScript)
            {
              result = MessageBox.Show("Analyze Done!\nShow output script(s) in default shell's file browser?", "Confirm", MessageBoxButtons.YesNo);
              if (result == DialogResult.Yes)
                processor.LaunchInExplorer(true);
            }
            else
            {
              result = MessageBox.Show("Analyze done!", "Analyze", MessageBoxButtons.OK);
            }

          }
          else
          {
            result = MessageBox.Show("Done!\nThe program will now attempt to execute the script(s).", "Confirm", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
              backgroundWorker2.RunWorkerAsync(processor);
            }
          }

        }
        else
        {
          MessageBox.Show("None of the files use an ordered chapter file.", "Confirm", MessageBoxButtons.OK);
        }

      } 

      this.Close();

    }

  //BackgroundWorker - Executes script after First BackgroundWorker (Main Process)
    private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
    {
      MainWindow.projectManager.analyze.ExecuteScript();
    }

    private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
    {
      ProjectManager project = MainWindow.projectManager;

      e.Result = project.analyze;

      MergeExecute merger = new MergeExecute(backgroundWorker3);

      progress = 1;
      processPercent = 0;

      foreach (FileObjectCollection fileList in project.analyze.fileLists)
      {

        if (backgroundWorker3.CancellationPending)
        {

          // Set the e.Cancel flag so that the WorkerCompleted event
          // knows that the process was cancelled.
          e.Cancel = true;
          return;
        }

        processPercent = progress.ToPercentage(project.analyze.fileLists.Count);

        progress++;

        merger.mergeExecute(fileList, project.analyze, false, processPercent);
      }

      if (backgroundWorker3.CancellationPending)
      {
        e.Cancel = true;
        return;
      }
      
    }

    private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      Analyze processor = e.Result as Analyze;
      DialogResult result = new DialogResult();

      // Check to see if an error occurred in the
      // background process.
      if (e.Error != null)
      {
        MessageBox.Show(e.Error.Message);
      }
      else

        // Check to see if the background process was cancelled.
        if (e.Cancelled)
        {
          MessageBox.Show("Processing cancelled.");
        }
        else
        {
          // Everything completed normally.
          // process the response using e.Result
          result = MessageBox.Show("Merging complete! View output files?", "Confirm", MessageBoxButtons.YesNo);

          if (result == DialogResult.Yes)
          {
            processor.LaunchInExplorer();
          }
        }

      this.Close();
    }

    private void stopButton_Click(object sender, EventArgs e)
    {
      stopButton.Text = "Cancelling...";
      backgroundWorker1.CancelAsync();
      stopButton.Enabled = false;
    }
  }
}
