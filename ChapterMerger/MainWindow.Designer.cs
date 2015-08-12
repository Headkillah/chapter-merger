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

using ChapterMerger;

namespace ChapterMergerForm
{
  partial class MainWindow
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.addFileButton = new System.Windows.Forms.Button();
      this.makeScriptButton = new System.Windows.Forms.Button();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.fileListLabel = new System.Windows.Forms.Label();
      this.optionsButton = new System.Windows.Forms.Button();
      this.openProjectButton = new System.Windows.Forms.Button();
      this.convertScriptButton = new System.Windows.Forms.Button();
      this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
      this.addFolderButton = new System.Windows.Forms.Button();
      this.clearListButton = new System.Windows.Forms.Button();
      this.fileListBox = new System.Windows.Forms.ListBox();
      this.analyzeButton = new System.Windows.Forms.Button();
      this.executeButton = new System.Windows.Forms.Button();
      this.saveProjectButton = new System.Windows.Forms.Button();
      this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.aboutButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.fileListPanel = new System.Windows.Forms.Panel();
      this.fileListPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // addFileButton
      // 
      this.addFileButton.Location = new System.Drawing.Point(12, 311);
      this.addFileButton.Name = "addFileButton";
      this.addFileButton.Size = new System.Drawing.Size(90, 23);
      this.addFileButton.TabIndex = 0;
      this.addFileButton.Text = "Add File(s)";
      this.addFileButton.UseVisualStyleBackColor = true;
      this.addFileButton.Click += new System.EventHandler(this.addFileButton_Click);
      // 
      // makeScriptButton
      // 
      this.makeScriptButton.Enabled = false;
      this.makeScriptButton.Location = new System.Drawing.Point(347, 133);
      this.makeScriptButton.Name = "makeScriptButton";
      this.makeScriptButton.Size = new System.Drawing.Size(133, 23);
      this.makeScriptButton.TabIndex = 3;
      this.makeScriptButton.Text = "Make Script(s)";
      this.makeScriptButton.UseVisualStyleBackColor = true;
      this.makeScriptButton.Visible = false;
      this.makeScriptButton.Click += new System.EventHandler(this.makeScriptButton_Click);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.Filter = "MKV files|*.mkv";
      this.openFileDialog1.Multiselect = true;
      this.openFileDialog1.Title = "Add File(s)";
      // 
      // fileListLabel
      // 
      this.fileListLabel.AutoSize = true;
      this.fileListLabel.Location = new System.Drawing.Point(9, 12);
      this.fileListLabel.Name = "fileListLabel";
      this.fileListLabel.Size = new System.Drawing.Size(116, 13);
      this.fileListLabel.TabIndex = 4;
      this.fileListLabel.Text = "Folders/files to process";
      // 
      // optionsButton
      // 
      this.optionsButton.Location = new System.Drawing.Point(347, 209);
      this.optionsButton.Name = "optionsButton";
      this.optionsButton.Size = new System.Drawing.Size(133, 23);
      this.optionsButton.TabIndex = 5;
      this.optionsButton.Text = "Options";
      this.optionsButton.UseVisualStyleBackColor = true;
      this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
      // 
      // openProjectButton
      // 
      this.openProjectButton.Location = new System.Drawing.Point(347, 28);
      this.openProjectButton.Name = "openProjectButton";
      this.openProjectButton.Size = new System.Drawing.Size(133, 23);
      this.openProjectButton.TabIndex = 8;
      this.openProjectButton.Text = "Open Project";
      this.openProjectButton.UseVisualStyleBackColor = true;
      this.openProjectButton.Click += new System.EventHandler(this.openProjectButton_Click);
      // 
      // convertScriptButton
      // 
      this.convertScriptButton.Enabled = false;
      this.convertScriptButton.Location = new System.Drawing.Point(347, 180);
      this.convertScriptButton.Name = "convertScriptButton";
      this.convertScriptButton.Size = new System.Drawing.Size(133, 23);
      this.convertScriptButton.TabIndex = 9;
      this.convertScriptButton.Text = "Make Converter Script";
      this.convertScriptButton.UseVisualStyleBackColor = true;
      // 
      // folderBrowserDialog1
      // 
      this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
      this.folderBrowserDialog1.ShowNewFolderButton = false;
      // 
      // addFolderButton
      // 
      this.addFolderButton.Location = new System.Drawing.Point(108, 311);
      this.addFolderButton.Name = "addFolderButton";
      this.addFolderButton.Size = new System.Drawing.Size(90, 23);
      this.addFolderButton.TabIndex = 10;
      this.addFolderButton.Text = "Add Folder";
      this.addFolderButton.UseVisualStyleBackColor = true;
      this.addFolderButton.Click += new System.EventHandler(this.addFolderButton_Click);
      // 
      // clearListButton
      // 
      this.clearListButton.Enabled = false;
      this.clearListButton.Location = new System.Drawing.Point(247, 311);
      this.clearListButton.Name = "clearListButton";
      this.clearListButton.Size = new System.Drawing.Size(90, 23);
      this.clearListButton.TabIndex = 11;
      this.clearListButton.Text = "Clear List";
      this.clearListButton.UseVisualStyleBackColor = true;
      this.clearListButton.Click += new System.EventHandler(this.clearListButton_Click);
      // 
      // fileListBox
      // 
      this.fileListBox.AllowDrop = true;
      this.fileListBox.FormattingEnabled = true;
      this.fileListBox.Location = new System.Drawing.Point(0, 0);
      this.fileListBox.Name = "fileListBox";
      this.fileListBox.Size = new System.Drawing.Size(325, 277);
      this.fileListBox.TabIndex = 15;
      this.fileListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileList_DragDrop);
      this.fileListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileList_DragEnter);
      // 
      // analyzeButton
      // 
      this.analyzeButton.Enabled = false;
      this.analyzeButton.Location = new System.Drawing.Point(347, 104);
      this.analyzeButton.Name = "analyzeButton";
      this.analyzeButton.Size = new System.Drawing.Size(133, 23);
      this.analyzeButton.TabIndex = 16;
      this.analyzeButton.Text = "Analyze";
      this.analyzeButton.UseVisualStyleBackColor = true;
      this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);
      // 
      // executeButton
      // 
      this.executeButton.Enabled = false;
      this.executeButton.Location = new System.Drawing.Point(347, 133);
      this.executeButton.Name = "executeButton";
      this.executeButton.Size = new System.Drawing.Size(133, 23);
      this.executeButton.TabIndex = 17;
      this.executeButton.Text = "Merge!";
      this.executeButton.UseVisualStyleBackColor = true;
      this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
      // 
      // saveProjectButton
      // 
      this.saveProjectButton.Enabled = false;
      this.saveProjectButton.Location = new System.Drawing.Point(347, 57);
      this.saveProjectButton.Name = "saveProjectButton";
      this.saveProjectButton.Size = new System.Drawing.Size(133, 23);
      this.saveProjectButton.TabIndex = 18;
      this.saveProjectButton.Text = "Save Project";
      this.saveProjectButton.UseVisualStyleBackColor = true;
      this.saveProjectButton.Click += new System.EventHandler(this.saveProjectButton_Click);
      // 
      // openFileDialog2
      // 
      this.openFileDialog2.Filter = "ChapterMerger Project File|*.cmproj";
      this.openFileDialog2.InitialDirectory = "C:\\Users\\caffe\\AppData\\Local\\Microsoft\\VisualStudio\\12.0\\ProjectAssemblies\\x7lvno" +
    "ko01";
      this.openFileDialog2.Title = "Open Project";
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.Filter = "ChapterMerger Project File|*.cmproj";
      this.saveFileDialog1.InitialDirectory = "C:\\Users\\caffe\\AppData\\Local\\Microsoft\\VisualStudio\\12.0\\ProjectAssemblies\\x7lvno" +
    "ko01";
      this.saveFileDialog1.Title = "Save Project File";
      this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
      // 
      // aboutButton
      // 
      this.aboutButton.Location = new System.Drawing.Point(347, 239);
      this.aboutButton.Name = "aboutButton";
      this.aboutButton.Size = new System.Drawing.Size(133, 23);
      this.aboutButton.TabIndex = 19;
      this.aboutButton.Text = "About Program";
      this.aboutButton.UseVisualStyleBackColor = true;
      this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(22, 110);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(280, 55);
      this.label1.TabIndex = 20;
      this.label1.Text = "You can drag files/folders to this area to add them. \r\n\r\nExternally linked files " +
    "must also be present inside the folder or alongside the files to process.";
      this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // fileListPanel
      // 
      this.fileListPanel.AllowDrop = true;
      this.fileListPanel.Controls.Add(this.fileListBox);
      this.fileListPanel.Controls.Add(this.label1);
      this.fileListPanel.Location = new System.Drawing.Point(12, 28);
      this.fileListPanel.Name = "fileListPanel";
      this.fileListPanel.Size = new System.Drawing.Size(325, 277);
      this.fileListPanel.TabIndex = 21;
      this.fileListPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileList_DragDrop);
      this.fileListPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileList_DragEnter);
      // 
      // MainWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(504, 358);
      this.Controls.Add(this.aboutButton);
      this.Controls.Add(this.saveProjectButton);
      this.Controls.Add(this.executeButton);
      this.Controls.Add(this.analyzeButton);
      this.Controls.Add(this.clearListButton);
      this.Controls.Add(this.addFolderButton);
      this.Controls.Add(this.convertScriptButton);
      this.Controls.Add(this.openProjectButton);
      this.Controls.Add(this.optionsButton);
      this.Controls.Add(this.fileListLabel);
      this.Controls.Add(this.makeScriptButton);
      this.Controls.Add(this.addFileButton);
      this.Controls.Add(this.fileListPanel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "MainWindow";
      this.Text = "ChapterMerger";
      this.Load += new System.EventHandler(this.MainWindow_Load);
      this.fileListPanel.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button addFileButton;
    private System.Windows.Forms.Button makeScriptButton;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Label fileListLabel;
    private System.Windows.Forms.Button optionsButton;
    private System.Windows.Forms.Button openProjectButton;
    private System.Windows.Forms.Button convertScriptButton;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    private System.Windows.Forms.Button addFolderButton;
    private System.Windows.Forms.Button clearListButton;
    private System.Windows.Forms.ListBox fileListBox;
    private System.Windows.Forms.Button analyzeButton;
    private System.Windows.Forms.Button executeButton;
    private System.Windows.Forms.Button saveProjectButton;
    private System.Windows.Forms.OpenFileDialog openFileDialog2;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.Button aboutButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel fileListPanel;
  }
}

