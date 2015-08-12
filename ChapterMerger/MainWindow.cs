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
using ChapterMerger;
using System.IO;

namespace ChapterMergerForm
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

      if (projectManager.argumentList.Count() > 0)
      {
        updateDisplay(projectManager.argumentList.ToArray());
      }
      else
        fileListViewInitialize();

      //execScriptCheckBox.Checked = Config.Configure.executeScriptAfter;

    }

  /// <summary>
  /// Enables or Disables sets of controls through the state variable passed
  /// </summary>
  /// <param name="state">State of the affected controls</param>
  /// <param name="listCount">The length of the item list passed. Affects certain controls.</param>
    private void ToggleEnableStates(bool state, int mode = 0)
    {
      //this.makeScriptButton.Enabled = state;
      //this.execScriptCheckBox.Enabled = state;
      this.analyzeButton.Enabled = state;
      //this.executeButton.Enabled = state;
      this.saveProjectButton.Enabled = state;
      this.clearListButton.Enabled = state;

      if (projectManager.analyze.hasOrdered)
        this.executeButton.Enabled = true;
      else
        this.executeButton.Enabled = false;

      //if (!state | mode == 1)
      //  this.executeButton.Enabled = false;

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

        updateDisplay(projectManager.argumentList.ToArray());

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


        updateDisplay(projectManager.argumentList.ToArray());

      }
    }

  //Button - Clears List
    private void clearListButton_Click(object sender, EventArgs e)
    {
      projectManager.ClearProject();
      
      fileListViewInitialize();

      ToggleEnableStates(false);
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
          if (Path.GetExtension(fileLoc) == ".mkv" || Path.GetExtension(fileLoc) == "")
          {
            if (!projectManager.argumentList.Contains(fileLoc))
            {
              projectManager.argumentList.Add(fileLoc);
            }
          }

        }

        if (projectManager.argumentList.Count > 0)
          updateDisplay(projectManager.argumentList.ToArray());

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
  /// <param name="items">The items to be added to update the file list box</param>
    private void addItems(string[] items)
    {

      if (!this.fileListBox.Visible)
        this.fileListBox.Show();

      fileListBox.Items.Clear();

      if (listViewIsInitialized)
        listViewIsInitialized = false;


      foreach (string item in items)
      {
        fileListBox.Items.Add(Path.GetFileName(item).TruncateMiddle(50));
      }
      
    }

  //Analyze files
    private void analyzeButton_Click(object sender, EventArgs e)
    {
      var arguments = projectManager.argumentList.ToArray();

      ProgressForm progressBar = new ProgressForm(arguments, true);
      progressBar.ShowDialog();

      if (Config.Configure.projectIncludeFileList && process != null)
      {
        projectManager.analyze.fileLists = process.fileLists;
        projectManager.analyze.hasOrdered = process.hasOrdered;
      }

      ToggleEnableStates(true);
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
      DialogResult result = openFileDialog2.ShowDialog();

      if (result == DialogResult.OK)
      {

        try
        {
          projectManager = ProjectManager.openProject(openFileDialog2.FileName);
          updateDisplay(projectManager.argumentList.ToArray(), 1);
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
      saveFileDialog1.ShowDialog();
    }

    private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
    {
      string file = saveFileDialog1.FileName;

      if (!Config.Configure.projectIncludeFileList && projectManager.analyze.fileLists.Count > 0)
      {
        projectManager.analyze = null;
      }

      try
      {
        projectManager.saveProject(file);
      }
      catch (Exception ex)
      {
        MessageBox.Show("Error:\r\n\r\n" + ex.Message, "Error");
      }

    }

  /// <summary>
  /// Updates the display that displays the file list.
  /// </summary>
  /// <param name="items">The updated item list to display.</param>
  /// <param name="mode">If 1, disables the merge button.</param>
    private void updateDisplay(string[] items, int mode = 0)
    {

      addItems(items);

      ToggleEnableStates(true, mode);

    }

    private void aboutButton_Click(object sender, EventArgs e)
    {
      About about = new About();
      about.ShowDialog();
    }

  }

}
