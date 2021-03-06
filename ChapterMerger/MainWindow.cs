﻿/*
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
using System.IO;

namespace ChapterMerger
{
  public partial class MainWindow : Form
  {

    private OptionsWindow optionDialog = new OptionsWindow();

    //private string[] args;

    private bool listViewIsInitialized = false;

    public static Analyze process;

    public static ProjectManager projectManager = new ProjectManager(Config.Configure);

    public MainWindow(string[] args)
    {
      if (args.Length > 0)
        foreach (string s in args)
          projectManager.argumentList.Add(s);

      InitializeComponent();
    }

  //Main Window OnLoad
    private void MainWindow_Load(object sender, EventArgs e)
    {

      this.Text = "ChapterMerger - New Project *";

      if (projectManager.argumentList.Count() > 0)
      {
        updateDisplay();
      }
      else
        fileListViewInitialize();

      //execScriptCheckBox.Checked = Config.Configure.executeScriptAfter;

    }

  /// <summary>
  /// Enables or Disables sets of controls depending on files added
  /// </summary>
    private void ToggleEnableStates()
    {
      bool state;

      if (projectManager.argumentList.Count > 0)
        state = true;
      else
        state = false;

      this.analyzeButton.Enabled = state;
      this.saveProjectButton.Enabled = state;
      this.clearListButton.Enabled = state;

      if (projectManager.analyze != null && projectManager.analyze.fileLists.Count > 0)
      {
        if (projectManager.analyze.hasOrdered)
        {
          this.executeButton.Enabled = true;
        }
        //Removed checking of hasFFmpeg as it is no longer necessary.
          this.convertButton.Enabled = true;
      }
      else
      {
        this.executeButton.Enabled = false;
        this.convertButton.Enabled = false;
      }

    }

  //Button - Dialog - Adds Files
    private void addFileButton_Click(object sender, EventArgs e)
    {
      DialogResult result = openFileDialog1.ShowDialog();

      if (result == DialogResult.OK) // Test result.
      {

        foreach (string fileName in openFileDialog1.FileNames)
        {
          if (!projectManager.argumentList.Contains(fileName))
          {
            projectManager.argumentList.Add(fileName);

          }
        }

        updateDisplay();

      }
    }

  //Button - Dialog - Adds Folder
    private void addFolderButton_Click(object sender, EventArgs e)
    {
      DialogResult result = folderBrowserDialog1.ShowDialog();

      if (result == DialogResult.OK) // Test result.
      {
        if (!projectManager.argumentList.Contains(folderBrowserDialog1.SelectedPath))
        {
          projectManager.argumentList.Add(folderBrowserDialog1.SelectedPath);
        }


        updateDisplay();

      }
    }

  //Button - Clears List
    private void clearListButton_Click(object sender, EventArgs e)
    {
      fileListViewInitialize();

      projectManager.ClearProject();

      updateDisplay();

    }

  /// <summary>
  /// Deprecated - Makes an executable batch script, that merges analyzed files
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
    private void makeScriptButton_Click(object sender, EventArgs e)
    {
      var arguments = projectManager.argumentList.ToArray();

      ProgressForm progressBar = new ProgressForm(arguments);
      progressBar.ShowDialog();
    }

    /*
     * 
  /// <summary>
  /// Deprecated - CheckBox - Execute Script
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>

    private void execScriptCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      Config.Configure.executeScriptAfter = execScriptCheckBox.Checked;
    }
     * 
     * */

  //Button - Options
    private void optionsButton_Click(object sender, EventArgs e)
    {
      optionDialog.ShowDialog();
    }

  //General List View Drag and Drop Methods
  /// <summary>
  /// Drag Drop Event - adds file to File List View after dropped
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
    private void fileList_DragDrop(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
        foreach (string fileLoc in filePaths)
        {
          /*
           * 
           * NOT used for performance reasons.
           * 
          foreach (string extension in MediaData.extensions)
            if (Path.GetExtension(fileLoc) == extension || Path.GetExtension(fileLoc) == "")
            {
              if (!projectManager.argumentList.Contains(fileLoc))
              {
                projectManager.argumentList.Add(fileLoc);
              }
            }
           * 
           * */

          if (!projectManager.argumentList.Contains(fileLoc))
          {
            projectManager.argumentList.Add(fileLoc);
          }

        }

        if (projectManager.argumentList.Count > 0)
          updateDisplay();

      }
    }

  /// <summary>
  /// Drag Enter - changes cursor icon when mouse enters the event area while dragging files
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
    private void fileList_DragEnter(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        e.Effect = DragDropEffects.Copy;
      }
      else
      {
        e.Effect = DragDropEffects.None;
      }
    }

  //Method - Initializes the current fileListView
    private void fileListViewInitialize()
    {

      fileListBox.Hide();

      listViewIsInitialized = true;

    }

  /// <summary>
  /// Add Items - this method is called when adding items, either through dialog or drag/drop events
  /// </summary>
    private void addItems()
    {

      if (projectManager.argumentList.Count > 0)
      {
        if (!this.fileListBox.Visible)
          this.fileListBox.Show();

        fileListBox.Items.Clear();

        if (listViewIsInitialized)
          listViewIsInitialized = false;


        foreach (string item in projectManager.argumentList)
        {
          fileListBox.Items.Add(Path.GetFileName(item).TruncateMiddle(50));
        }

      }
      else
      {
        this.fileListBox.Hide();
      }
      
    }

  //Analyze files
    private void analyzeButton_Click(object sender, EventArgs e)
    {
      var arguments = projectManager.argumentList.ToArray();

      ProgressForm progressBar = new ProgressForm(arguments, true);
      progressBar.ShowDialog();

      /*
      if (Config.Configure.projectIncludeFileList && process != null)
      {
        projectManager.analyze.fileLists = process.fileLists;
        projectManager.analyze.hasOrdered = process.hasOrdered;
      }
       * 
       * */

      ToggleEnableStates();
    }

  //Merge! - executeButton
    private void executeButton_Click(object sender, EventArgs e)
    {
      //ExecuteProgressForm execute = new ExecuteProgressForm();
      //execute.ShowDialog();
      ProgressForm progressBar = new ProgressForm(true);
      progressBar.ShowDialog();
    }

  /// <summary>
  /// Try to open a saved ProjectManager object.
  /// If it fails, display a message.
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
    private void openProjectButton_Click(object sender, EventArgs e)
    {
      //openFileDialog2.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath); //Chose current user's documents path instead
      openFileDialog2.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
      DialogResult result = openFileDialog2.ShowDialog();

      if (result == DialogResult.OK)
      {

        try
        {
          projectManager = ProjectManager.openProject(openFileDialog2.FileName);

          updateDisplay();
        }
        catch (Exception ex)
        {
          MessageBox.Show("Error:\r\n\r\n" + ex.Message + "\r\n\r\nProject file is corrupted.", "Error");
        }
        
      }
    }

  /// <summary>
  /// Save File Dialog: tries to save a projectManager object as a file.
  /// If it fails, display the Exception message.
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
    private void saveProjectButton_Click(object sender, EventArgs e)
    {
      saveFileDialog1.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
      saveFileDialog1.ShowDialog();
    }

    private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
    {
      string file = saveFileDialog1.FileName;

      /*
       * Deprecated
       * What this does to exclude analyzed filelist is clear the actual analyze object, which is undesirable.
       * 
      if (!Config.Configure.projectIncludeFileList && projectManager.analyze.fileLists.Count > 0)
      {
        projectManager.analyze = null;
      }
       * */

      try
      {
        projectManager.saveProject(file);
        projectManager.projectFileName = Path.GetFileName(file);
        updateDisplay();
      }
      catch (Exception ex)
      {
        MessageBox.Show("Error:\r\n\r\n" + ex.Message, "Error");
      }

    }

  /// <summary>
  /// Updates the display that displays the file list.
  /// </summary>
  /// <param name="mode">If 1, disables the merge button.</param>
    private void updateDisplay()
    {

      addItems();

      ToggleEnableStates();

      if (projectManager.argumentList.Count < 1 && String.IsNullOrWhiteSpace(projectManager.projectFileName))
        this.Text = "ChapterMerger - New Project *";
      else if (!String.IsNullOrWhiteSpace(projectManager.projectFileName))
        this.Text = "ChapterMerger - " + projectManager.projectFileName + " *";
      else
        this.Text = "ChapterMerger - " + Path.GetFileName(openFileDialog2.FileName) + " *";

    }

    private void aboutButton_Click(object sender, EventArgs e)
    {
      About about = new About();
      about.ShowDialog();
    }

    private void convertButton_Click(object sender, EventArgs e)
    {
      Program.checkDependencies();  //This makes the program check for dependencies again during runtime.

      if (!Program.hasFFmpeg)
        MessageBox.Show("To use this functionality, FFmpeg must exist in the same directory as this program, or in the PATH variable.\r\n\r\nYou can get ffmpeg here:\r\n https://ffmpeg.org/download.html", "Information");
      else
      {
        ProgressForm progressBar = new ProgressForm(2);
        progressBar.ShowDialog();
      }

    }

    /// <summary>
    /// Diagnostic. Demo method for chapter file parsing.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void parseXmlButton_Click(object sender, EventArgs e)
    {
      DialogResult result = openFileDialog3.ShowDialog();

      if (result == DialogResult.OK)
      {

        try
        {
          ChaptersObject chapter = ChaptersObject.LoadChapterFile(openFileDialog3.FileName);

          MessageBox.Show(chapter.InterpretChapterFile());

          chapter.SaveChapterFile(Path.Combine(Program.defaultPath, Path.GetFileNameWithoutExtension(openFileDialog3.FileName) + "_parsed" + Path.GetExtension(openFileDialog3.FileName)));
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message);
        }

      }
    }
  }
}
