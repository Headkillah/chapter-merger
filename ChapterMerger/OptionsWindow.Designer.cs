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

namespace ChapterMerger
{
  partial class OptionsWindow
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.fileOptionsGroupBox = new System.Windows.Forms.GroupBox();
      this.newFileSuffixTextBox = new System.Windows.Forms.TextBox();
      this.newFilePrefixTextBox = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.diagnoseGroupBox = new System.Windows.Forms.GroupBox();
      this.dumpInfoCheckBox = new System.Windows.Forms.CheckBox();
      this.dumpChapterInfoCheckBox = new System.Windows.Forms.CheckBox();
      this.generalGroupBox = new System.Windows.Forms.GroupBox();
      this.noChapterCheckBox = new System.Windows.Forms.CheckBox();
      this.alwaysMergeCheckBox = new System.Windows.Forms.CheckBox();
      this.sourceOutputCheckBox = new System.Windows.Forms.CheckBox();
      this.splitModeGroupBox = new System.Windows.Forms.GroupBox();
      this.timeStartRadioButton = new System.Windows.Forms.RadioButton();
      this.timeEndRadioButton = new System.Windows.Forms.RadioButton();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.defaultButton = new System.Windows.Forms.Button();
      this.projectIncludeFileListCheckBox = new System.Windows.Forms.CheckBox();
      this.panel1.SuspendLayout();
      this.fileOptionsGroupBox.SuspendLayout();
      this.diagnoseGroupBox.SuspendLayout();
      this.generalGroupBox.SuspendLayout();
      this.splitModeGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.fileOptionsGroupBox);
      this.panel1.Controls.Add(this.diagnoseGroupBox);
      this.panel1.Controls.Add(this.generalGroupBox);
      this.panel1.Controls.Add(this.splitModeGroupBox);
      this.panel1.Location = new System.Drawing.Point(13, 13);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(236, 391);
      this.panel1.TabIndex = 0;
      // 
      // fileOptionsGroupBox
      // 
      this.fileOptionsGroupBox.Controls.Add(this.newFileSuffixTextBox);
      this.fileOptionsGroupBox.Controls.Add(this.newFilePrefixTextBox);
      this.fileOptionsGroupBox.Controls.Add(this.label4);
      this.fileOptionsGroupBox.Controls.Add(this.label3);
      this.fileOptionsGroupBox.Location = new System.Drawing.Point(3, 302);
      this.fileOptionsGroupBox.Name = "fileOptionsGroupBox";
      this.fileOptionsGroupBox.Size = new System.Drawing.Size(230, 81);
      this.fileOptionsGroupBox.TabIndex = 13;
      this.fileOptionsGroupBox.TabStop = false;
      this.fileOptionsGroupBox.Text = "Output File Naming";
      // 
      // newFileSuffixTextBox
      // 
      this.newFileSuffixTextBox.Location = new System.Drawing.Point(87, 23);
      this.newFileSuffixTextBox.Name = "newFileSuffixTextBox";
      this.newFileSuffixTextBox.Size = new System.Drawing.Size(116, 20);
      this.newFileSuffixTextBox.TabIndex = 5;
      // 
      // newFilePrefixTextBox
      // 
      this.newFilePrefixTextBox.Location = new System.Drawing.Point(87, 50);
      this.newFilePrefixTextBox.Name = "newFilePrefixTextBox";
      this.newFilePrefixTextBox.Size = new System.Drawing.Size(116, 20);
      this.newFilePrefixTextBox.TabIndex = 9;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 53);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(80, 13);
      this.label4.TabIndex = 8;
      this.label4.Text = "New File Prefix:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 26);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(80, 13);
      this.label3.TabIndex = 7;
      this.label3.Text = "New File Suffix:";
      // 
      // diagnoseGroupBox
      // 
      this.diagnoseGroupBox.Controls.Add(this.dumpInfoCheckBox);
      this.diagnoseGroupBox.Controls.Add(this.dumpChapterInfoCheckBox);
      this.diagnoseGroupBox.Location = new System.Drawing.Point(3, 129);
      this.diagnoseGroupBox.Name = "diagnoseGroupBox";
      this.diagnoseGroupBox.Size = new System.Drawing.Size(230, 66);
      this.diagnoseGroupBox.TabIndex = 0;
      this.diagnoseGroupBox.TabStop = false;
      this.diagnoseGroupBox.Text = "Diagnostics";
      // 
      // dumpInfoCheckBox
      // 
      this.dumpInfoCheckBox.AutoSize = true;
      this.dumpInfoCheckBox.Location = new System.Drawing.Point(6, 19);
      this.dumpInfoCheckBox.Name = "dumpInfoCheckBox";
      this.dumpInfoCheckBox.Size = new System.Drawing.Size(97, 17);
      this.dumpInfoCheckBox.TabIndex = 11;
      this.dumpInfoCheckBox.Text = "Dump mkv info";
      this.dumpInfoCheckBox.UseVisualStyleBackColor = true;
      // 
      // dumpChapterInfoCheckBox
      // 
      this.dumpChapterInfoCheckBox.AutoSize = true;
      this.dumpChapterInfoCheckBox.Location = new System.Drawing.Point(6, 42);
      this.dumpChapterInfoCheckBox.Name = "dumpChapterInfoCheckBox";
      this.dumpChapterInfoCheckBox.Size = new System.Drawing.Size(118, 17);
      this.dumpChapterInfoCheckBox.TabIndex = 12;
      this.dumpChapterInfoCheckBox.Text = "Dump chapter infos";
      this.dumpChapterInfoCheckBox.UseVisualStyleBackColor = true;
      // 
      // generalGroupBox
      // 
      this.generalGroupBox.Controls.Add(this.projectIncludeFileListCheckBox);
      this.generalGroupBox.Controls.Add(this.noChapterCheckBox);
      this.generalGroupBox.Controls.Add(this.alwaysMergeCheckBox);
      this.generalGroupBox.Controls.Add(this.sourceOutputCheckBox);
      this.generalGroupBox.Location = new System.Drawing.Point(3, 3);
      this.generalGroupBox.Name = "generalGroupBox";
      this.generalGroupBox.Size = new System.Drawing.Size(230, 120);
      this.generalGroupBox.TabIndex = 2;
      this.generalGroupBox.TabStop = false;
      this.generalGroupBox.Text = "General";
      // 
      // noChapterCheckBox
      // 
      this.noChapterCheckBox.AutoSize = true;
      this.noChapterCheckBox.Enabled = false;
      this.noChapterCheckBox.Location = new System.Drawing.Point(5, 62);
      this.noChapterCheckBox.Name = "noChapterCheckBox";
      this.noChapterCheckBox.Size = new System.Drawing.Size(143, 17);
      this.noChapterCheckBox.TabIndex = 2;
      this.noChapterCheckBox.Text = "No chapter file on output";
      this.noChapterCheckBox.UseVisualStyleBackColor = true;
      // 
      // alwaysMergeCheckBox
      // 
      this.alwaysMergeCheckBox.AutoSize = true;
      this.alwaysMergeCheckBox.Enabled = false;
      this.alwaysMergeCheckBox.Location = new System.Drawing.Point(5, 39);
      this.alwaysMergeCheckBox.Name = "alwaysMergeCheckBox";
      this.alwaysMergeCheckBox.Size = new System.Drawing.Size(154, 17);
      this.alwaysMergeCheckBox.TabIndex = 1;
      this.alwaysMergeCheckBox.Text = "Always merge after analyze";
      this.alwaysMergeCheckBox.UseVisualStyleBackColor = true;
      // 
      // sourceOutputCheckBox
      // 
      this.sourceOutputCheckBox.AutoSize = true;
      this.sourceOutputCheckBox.Location = new System.Drawing.Point(6, 16);
      this.sourceOutputCheckBox.Name = "sourceOutputCheckBox";
      this.sourceOutputCheckBox.Size = new System.Drawing.Size(127, 17);
      this.sourceOutputCheckBox.TabIndex = 0;
      this.sourceOutputCheckBox.Text = "Source Folder Output";
      this.sourceOutputCheckBox.UseVisualStyleBackColor = true;
      // 
      // splitModeGroupBox
      // 
      this.splitModeGroupBox.Controls.Add(this.timeStartRadioButton);
      this.splitModeGroupBox.Controls.Add(this.timeEndRadioButton);
      this.splitModeGroupBox.Location = new System.Drawing.Point(3, 201);
      this.splitModeGroupBox.Name = "splitModeGroupBox";
      this.splitModeGroupBox.Size = new System.Drawing.Size(230, 95);
      this.splitModeGroupBox.TabIndex = 16;
      this.splitModeGroupBox.TabStop = false;
      this.splitModeGroupBox.Text = "Split Mode";
      // 
      // timeStartRadioButton
      // 
      this.timeStartRadioButton.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
      this.timeStartRadioButton.Location = new System.Drawing.Point(6, 43);
      this.timeStartRadioButton.Name = "timeStartRadioButton";
      this.timeStartRadioButton.Size = new System.Drawing.Size(217, 43);
      this.timeStartRadioButton.TabIndex = 1;
      this.timeStartRadioButton.TabStop = true;
      this.timeStartRadioButton.Text = "On time start — choose only if default option is largely inaccurate (often has th" +
    "e same results)";
      this.timeStartRadioButton.UseVisualStyleBackColor = true;
      // 
      // timeEndRadioButton
      // 
      this.timeEndRadioButton.AutoSize = true;
      this.timeEndRadioButton.Location = new System.Drawing.Point(6, 20);
      this.timeEndRadioButton.Name = "timeEndRadioButton";
      this.timeEndRadioButton.Size = new System.Drawing.Size(196, 17);
      this.timeEndRadioButton.TabIndex = 0;
      this.timeEndRadioButton.TabStop = true;
      this.timeEndRadioButton.Text = "On time end (default; recommended)";
      this.timeEndRadioButton.UseVisualStyleBackColor = true;
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(267, 16);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(123, 23);
      this.okButton.TabIndex = 1;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.okButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Location = new System.Drawing.Point(267, 45);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(123, 23);
      this.cancelButton.TabIndex = 2;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // defaultButton
      // 
      this.defaultButton.Location = new System.Drawing.Point(267, 74);
      this.defaultButton.Name = "defaultButton";
      this.defaultButton.Size = new System.Drawing.Size(123, 23);
      this.defaultButton.TabIndex = 3;
      this.defaultButton.Text = "Restore Defaults";
      this.defaultButton.UseVisualStyleBackColor = true;
      this.defaultButton.Click += new System.EventHandler(this.defaultButton_Click);
      // 
      // projectIncludeFileListCheckBox
      // 
      this.projectIncludeFileListCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
      this.projectIncludeFileListCheckBox.Location = new System.Drawing.Point(5, 82);
      this.projectIncludeFileListCheckBox.Name = "projectIncludeFileListCheckBox";
      this.projectIncludeFileListCheckBox.Size = new System.Drawing.Size(219, 30);
      this.projectIncludeFileListCheckBox.TabIndex = 3;
      this.projectIncludeFileListCheckBox.Text = "Include analyzed data on project file (results in larger project file size)";
      this.projectIncludeFileListCheckBox.UseVisualStyleBackColor = true;
      // 
      // OptionsWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(402, 413);
      this.Controls.Add(this.defaultButton);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "OptionsWindow";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Options";
      this.Load += new System.EventHandler(this.OptionsWindow_Load);
      this.panel1.ResumeLayout(false);
      this.fileOptionsGroupBox.ResumeLayout(false);
      this.fileOptionsGroupBox.PerformLayout();
      this.diagnoseGroupBox.ResumeLayout(false);
      this.diagnoseGroupBox.PerformLayout();
      this.generalGroupBox.ResumeLayout(false);
      this.generalGroupBox.PerformLayout();
      this.splitModeGroupBox.ResumeLayout(false);
      this.splitModeGroupBox.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.CheckBox noChapterCheckBox;
    private System.Windows.Forms.CheckBox alwaysMergeCheckBox;
    private System.Windows.Forms.CheckBox sourceOutputCheckBox;
    private System.Windows.Forms.CheckBox dumpChapterInfoCheckBox;
    private System.Windows.Forms.CheckBox dumpInfoCheckBox;
    private System.Windows.Forms.GroupBox splitModeGroupBox;
    private System.Windows.Forms.RadioButton timeStartRadioButton;
    private System.Windows.Forms.RadioButton timeEndRadioButton;
    private System.Windows.Forms.GroupBox diagnoseGroupBox;
    private System.Windows.Forms.GroupBox generalGroupBox;
    private System.Windows.Forms.GroupBox fileOptionsGroupBox;
    private System.Windows.Forms.TextBox newFilePrefixTextBox;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button defaultButton;
    private System.Windows.Forms.TextBox newFileSuffixTextBox;
    private System.Windows.Forms.CheckBox projectIncludeFileListCheckBox;
  }
}