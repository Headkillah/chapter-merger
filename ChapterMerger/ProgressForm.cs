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
    private bool doConvert = false;

    private int progress;
    private int processPercent;

    public Analyze analyzeData = MainWindow.projectManager.analyze;

  /// <summary>
  /// Create a ProgressForm with default options. The current default behavior is to analyze current file list.
  /// </summary>
    public ProgressForm()
    {
      InitializeComponent();
    }

  /// <summary>
  /// Gets the passed list of argument and analyzes it by using the Analyze instance.
  /// </summary>
  /// <param name="args">A string array that includes all filelist view arguments.</param>
    public ProgressForm(string[] args)
    {
      this.args = args;

      InitializeComponent();
      
    }

    /// <summary>
    /// Gets the passed list of argument and analyzes it by using an Analyze instance.
    /// </summary>
    /// <param name="args">A string array that includes all filelist view arguments.</param>
    /// <param name="analyzeData">The Analyze instance to use.</param>
    public ProgressForm(string[] args, Analyze analyzeData)
    {
      this.args = args;
      this.analyzeData = analyzeData;

      InitializeComponent();

    }

  /// <summary>
  /// Deprecated. Create a ProgressForm and sets its doMerge value
  /// </summary>
  /// <param name="doMerge">If true, calls the merge method, using the processed filelists in the main Processor instance.</param>
    public ProgressForm(bool doMerge)
    {
      this.doMerge = doMerge;
      InitializeComponent();
    }

    /// <summary>
    /// Create a ProgressForm with different modes, with the default ProjectManager Analyze instance.
    /// </summary>
    /// <param name="mode">Modes: 0 for XML creation (deprecated), 1 for merge, 2 for convert.</param>
    public ProgressForm(int mode)
    {
      switch (mode)
      {
        case 0:
          this.doMakeXml = true;
          break;
        case 1:
          this.doMerge = true;
          break;
        case 2:
          this.doConvert = true;
          break;
        default:
          break;
      }

      analyzeData = MainWindow.projectManager.analyze;

      InitializeComponent();
    }

    /// <summary>
    /// Deprecated. Create a ProgressForm with file lists to process
    /// </summary>
    /// <param name="args">A string array that includes all filelist view arguments.</param>
    /// <param name="doMakeXml">If true, create the analyzed data in an XML.</param>
    public ProgressForm(string[] args, bool doMakeXml)
    {
      this.args = args;
      this.doMakeXml = doMakeXml;

      InitializeComponent();

    }

    /// <summary>
    /// Create a ProgressForm with different modes, and a custom Analyze instance.
    /// </summary>
    /// <param name="mode">Modes: 0 for XML creation (deprecated), 1 for merge, 2 for convert.</param>
    /// <param name="analyzeData">The Analyze instance to use for the mode.</param>
    public ProgressForm(int mode, Analyze analyzeData)
    {
      switch (mode)
      {
        case 0:
          this.doMakeXml = true;
          break;
        case 1:
          this.doMerge = true;
          break;
        case 2:
          this.doConvert = true;
          break;
        default:
          break;
      }

      this.analyzeData = analyzeData;

      InitializeComponent();
    }

  //ProgressForm OnLoad
    private void ProgressForm_Load(object sender, EventArgs e)
    {
      if (doMerge)
      {
        backgroundWorker3.RunWorkerAsync();
      }
      else if (doConvert)
        backgroundWorker4.RunWorkerAsync();
      else
        backgroundWorker1.RunWorkerAsync();
    }

  //BackgroundWorker - Main analyze process for files
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      var previousData = analyzeData;

      analyzeData = new Analyze(backgroundWorker1);

      analyzeData.process(args);

      if (backgroundWorker1.CancellationPending)
      {
        e.Cancel = true;
        return;
      }

      if (previousData == MainWindow.projectManager.analyze)
        MainWindow.projectManager.analyze = analyzeData;

      e.Result = analyzeData;

    }

  //Global BackgroundWorker ProgressChanged.
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

  //Deprecated. BackgroundWorker - Executes script after First BackgroundWorker (Main Process)
    private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
    {
      MainWindow.projectManager.analyze.ExecuteScript();
    }

  //BackgroundWorker - Merges analyzed data from backgroundWorker1 that has ordered chapter.
    private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
    {
      e.Result = analyzeData;

      Merger merger = new Merger(backgroundWorker3);

      progress = 1;
      processPercent = 0;

      Analyze.outputGroups.Clear();

      foreach (FileObjectCollection fileList in analyzeData.fileLists)
      {

        if (backgroundWorker3.CancellationPending)
        {

          // Set the e.Cancel flag so that the WorkerCompleted event
          // knows that the process was cancelled.
          e.Cancel = true;
          return;
        }

        processPercent = progress.ToPercentage(analyzeData.fileLists.Count);

        progress++;

        merger.Merge(fileList, analyzeData, false, processPercent);
      }

      if (backgroundWorker3.CancellationPending)
      {
        e.Cancel = true;
        return;
      }
      
    }

    private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      //var dialogComplete = new CustomDialog();

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
          Analyze processor = e.Result as Analyze;

          var dialogComplete = new CustomDialog("Merging complete!", "Confirm", "OK", "Convert", "View in Explorer");

          result = dialogComplete.ShowDialog();

          //result = CustomDialog.Show("Merging complete!\n\nBut!\n\nWait!\n\nThere's more to it than it seems apparently through your boggling eyes (Yes, that's a new English word).\n\nOkay.", "Confirm", "OK", "Convert", "View in Explorer");

          if (result == DialogResult.OK)
          {

            if (dialogComplete.buttonPressed == "View in Explorer")
              processor.LaunchInExplorer();
            else if (dialogComplete.buttonPressed == "Convert")
            {

              Analyze analyzeMerged = new Analyze();

              var mergedAnalyze = new ProgressForm(Analyze.outputGroups.ToArray(), analyzeMerged);

              mergedAnalyze.ShowDialog();

              analyzeMerged = mergedAnalyze.analyzeData;

              var mergedConvert = new ProgressForm(2, analyzeMerged);
              
              mergedConvert.ShowDialog();

            }
            else
              this.Close();

          }
        }

      this.Close();
    }

  //Stops the current BackgroundWorker.
    private void stopButton_Click(object sender, EventArgs e)
    {
      stopButton.Text = "Cancelling...";
      if (doMerge)
        backgroundWorker3.CancelAsync();
      else if (doConvert)
        backgroundWorker4.CancelAsync();
      else
        backgroundWorker1.CancelAsync();
      stopButton.Enabled = false;
    }

  //BackgroundWorker - Execute Conversion
    private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
    {

      e.Result = analyzeData;

      Converter converter = new Converter(Config.Configure.ConvertConfigure, backgroundWorker4);

      progress = 1;
      processPercent = 0;

      Analyze.outputGroups.Clear();

      foreach (FileObjectCollection fileList in analyzeData.fileLists)
      {

        if (backgroundWorker4.CancellationPending)
        {

          // Set the e.Cancel flag so that the WorkerCompleted event
          // knows that the process was cancelled.
          e.Cancel = true;
          return;
        }

        processPercent = progress.ToPercentage(analyzeData.fileLists.Count);

        progress++;

        converter.Convert(fileList, processPercent);
      }

      if (backgroundWorker4.CancellationPending)
      {
        e.Cancel = true;
        return;
      }
    }

    private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
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
        // If shutdownDevice is true, shutdown the computer.
        else if (Config.Configure.ConvertConfigure.shutdownDevice)
        {
          Program.ShutdownDevice();
        } 
        else
        {
          // Everything completed normally.
          // process the response using e.Result
          Analyze processor = e.Result as Analyze;
          result = MessageBox.Show("Conversion complete! View output files?", "Confirm", MessageBoxButtons.YesNo);

          if (result == DialogResult.Yes)
          {
            processor.LaunchInExplorer();
          }
        }

      this.Close();
    }
  }
}
