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
  partial class OptionsConvertWindow
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
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.generalTabPage = new System.Windows.Forms.TabPage();
      this.mappingGroupBox = new System.Windows.Forms.GroupBox();
      this.incAttSCheckBox = new System.Windows.Forms.CheckBox();
      this.incSubSCheckBox = new System.Windows.Forms.CheckBox();
      this.incAudSCheckBox = new System.Windows.Forms.CheckBox();
      this.incVidSCheckBox = new System.Windows.Forms.CheckBox();
      this.generalGroupBox = new System.Windows.Forms.GroupBox();
      this.akbitTextBox = new System.Windows.Forms.TextBox();
      this.vkbitTextBox = new System.Windows.Forms.TextBox();
      this.vwidthTextBox = new System.Windows.Forms.TextBox();
      this.vheightTextBox = new System.Windows.Forms.TextBox();
      this.acodecComboBox = new System.Windows.Forms.ComboBox();
      this.vcodecComboBox = new System.Windows.Forms.ComboBox();
      this.resizeVidCheckBox = new System.Windows.Forms.CheckBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.akbitLabel = new System.Windows.Forms.Label();
      this.vkbitLabel = new System.Windows.Forms.Label();
      this.acodecLabel = new System.Windows.Forms.Label();
      this.vcodecLabel = new System.Windows.Forms.Label();
      this.fileOptionsGroupBox = new System.Windows.Forms.GroupBox();
      this.newFileSuffixTextBox = new System.Windows.Forms.TextBox();
      this.newFilePrefixTextBox = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.specTabPage = new System.Windows.Forms.TabPage();
      this.x264GroupBox = new System.Windows.Forms.GroupBox();
      this.x264crfTextBox = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.x264hi10CheckBox = new System.Windows.Forms.CheckBox();
      this.x264presetComboBox = new System.Windows.Forms.ComboBox();
      this.x264tuneComboBox = new System.Windows.Forms.ComboBox();
      this.label10 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.subsTabPage = new System.Windows.Forms.TabPage();
      this.subIndexTextBox = new System.Windows.Forms.TextBox();
      this.extSubFormatComboBox = new System.Windows.Forms.ComboBox();
      this.label16 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.subsFilterCheckBox = new System.Windows.Forms.CheckBox();
      this.extSubCheckBox = new System.Windows.Forms.CheckBox();
      this.advancedTabPage = new System.Windows.Forms.TabPage();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label5 = new System.Windows.Forms.Label();
      this.shutdownCheckBox = new System.Windows.Forms.CheckBox();
      this.vidScalerComboBox = new System.Windows.Forms.ComboBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label13 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.custFFmpegTextBox = new System.Windows.Forms.TextBox();
      this.custMapOptionsTextBox = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.custVidFilterTextBox = new System.Windows.Forms.TextBox();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.defaultButton = new System.Windows.Forms.Button();
      this.label15 = new System.Windows.Forms.Label();
      this.formatLabel = new System.Windows.Forms.Label();
      this.formatComboBox = new System.Windows.Forms.ComboBox();
      this.h264profileComboBox = new System.Windows.Forms.ComboBox();
      this.label17 = new System.Windows.Forms.Label();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.experAudCodecCheckBox = new System.Windows.Forms.CheckBox();
      this.label18 = new System.Windows.Forms.Label();
      this.x264advancedGroupBox = new System.Windows.Forms.GroupBox();
      this.panel1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.generalTabPage.SuspendLayout();
      this.mappingGroupBox.SuspendLayout();
      this.generalGroupBox.SuspendLayout();
      this.fileOptionsGroupBox.SuspendLayout();
      this.specTabPage.SuspendLayout();
      this.x264GroupBox.SuspendLayout();
      this.subsTabPage.SuspendLayout();
      this.advancedTabPage.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.x264advancedGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.tabControl1);
      this.panel1.Location = new System.Drawing.Point(13, 13);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(354, 412);
      this.panel1.TabIndex = 0;
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.generalTabPage);
      this.tabControl1.Controls.Add(this.specTabPage);
      this.tabControl1.Controls.Add(this.subsTabPage);
      this.tabControl1.Controls.Add(this.advancedTabPage);
      this.tabControl1.Location = new System.Drawing.Point(3, 3);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(348, 403);
      this.tabControl1.TabIndex = 19;
      // 
      // generalTabPage
      // 
      this.generalTabPage.AutoScroll = true;
      this.generalTabPage.Controls.Add(this.mappingGroupBox);
      this.generalTabPage.Controls.Add(this.generalGroupBox);
      this.generalTabPage.Controls.Add(this.fileOptionsGroupBox);
      this.generalTabPage.Location = new System.Drawing.Point(4, 22);
      this.generalTabPage.Name = "generalTabPage";
      this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.generalTabPage.Size = new System.Drawing.Size(340, 377);
      this.generalTabPage.TabIndex = 0;
      this.generalTabPage.Text = "General";
      this.generalTabPage.UseVisualStyleBackColor = true;
      // 
      // mappingGroupBox
      // 
      this.mappingGroupBox.Controls.Add(this.incAttSCheckBox);
      this.mappingGroupBox.Controls.Add(this.incSubSCheckBox);
      this.mappingGroupBox.Controls.Add(this.incAudSCheckBox);
      this.mappingGroupBox.Controls.Add(this.incVidSCheckBox);
      this.mappingGroupBox.Location = new System.Drawing.Point(6, 315);
      this.mappingGroupBox.Name = "mappingGroupBox";
      this.mappingGroupBox.Size = new System.Drawing.Size(311, 115);
      this.mappingGroupBox.TabIndex = 14;
      this.mappingGroupBox.TabStop = false;
      this.mappingGroupBox.Text = "Simple Output Mapping Options";
      // 
      // incAttSCheckBox
      // 
      this.incAttSCheckBox.AutoSize = true;
      this.incAttSCheckBox.Location = new System.Drawing.Point(8, 88);
      this.incAttSCheckBox.Name = "incAttSCheckBox";
      this.incAttSCheckBox.Size = new System.Drawing.Size(156, 17);
      this.incAttSCheckBox.TabIndex = 3;
      this.incAttSCheckBox.Text = "Include attachment streams";
      this.incAttSCheckBox.UseVisualStyleBackColor = true;
      // 
      // incSubSCheckBox
      // 
      this.incSubSCheckBox.AutoSize = true;
      this.incSubSCheckBox.Location = new System.Drawing.Point(8, 65);
      this.incSubSCheckBox.Name = "incSubSCheckBox";
      this.incSubSCheckBox.Size = new System.Drawing.Size(136, 17);
      this.incSubSCheckBox.TabIndex = 2;
      this.incSubSCheckBox.Text = "Include subtitle streams";
      this.incSubSCheckBox.UseVisualStyleBackColor = true;
      // 
      // incAudSCheckBox
      // 
      this.incAudSCheckBox.AutoSize = true;
      this.incAudSCheckBox.Location = new System.Drawing.Point(8, 42);
      this.incAudSCheckBox.Name = "incAudSCheckBox";
      this.incAudSCheckBox.Size = new System.Drawing.Size(129, 17);
      this.incAudSCheckBox.TabIndex = 1;
      this.incAudSCheckBox.Text = "Include audio streams";
      this.incAudSCheckBox.UseVisualStyleBackColor = true;
      // 
      // incVidSCheckBox
      // 
      this.incVidSCheckBox.AutoSize = true;
      this.incVidSCheckBox.Location = new System.Drawing.Point(8, 19);
      this.incVidSCheckBox.Name = "incVidSCheckBox";
      this.incVidSCheckBox.Size = new System.Drawing.Size(129, 17);
      this.incVidSCheckBox.TabIndex = 0;
      this.incVidSCheckBox.Text = "Include video streams";
      this.incVidSCheckBox.UseVisualStyleBackColor = true;
      // 
      // generalGroupBox
      // 
      this.generalGroupBox.Controls.Add(this.formatComboBox);
      this.generalGroupBox.Controls.Add(this.formatLabel);
      this.generalGroupBox.Controls.Add(this.label15);
      this.generalGroupBox.Controls.Add(this.akbitTextBox);
      this.generalGroupBox.Controls.Add(this.vkbitTextBox);
      this.generalGroupBox.Controls.Add(this.vwidthTextBox);
      this.generalGroupBox.Controls.Add(this.vheightTextBox);
      this.generalGroupBox.Controls.Add(this.acodecComboBox);
      this.generalGroupBox.Controls.Add(this.vcodecComboBox);
      this.generalGroupBox.Controls.Add(this.resizeVidCheckBox);
      this.generalGroupBox.Controls.Add(this.label2);
      this.generalGroupBox.Controls.Add(this.label1);
      this.generalGroupBox.Controls.Add(this.akbitLabel);
      this.generalGroupBox.Controls.Add(this.vkbitLabel);
      this.generalGroupBox.Controls.Add(this.acodecLabel);
      this.generalGroupBox.Controls.Add(this.vcodecLabel);
      this.generalGroupBox.Location = new System.Drawing.Point(6, 7);
      this.generalGroupBox.Name = "generalGroupBox";
      this.generalGroupBox.Size = new System.Drawing.Size(311, 302);
      this.generalGroupBox.TabIndex = 2;
      this.generalGroupBox.TabStop = false;
      this.generalGroupBox.Text = "General";
      // 
      // akbitTextBox
      // 
      this.akbitTextBox.Location = new System.Drawing.Point(121, 217);
      this.akbitTextBox.MaxLength = 10;
      this.akbitTextBox.Name = "akbitTextBox";
      this.akbitTextBox.Size = new System.Drawing.Size(82, 20);
      this.akbitTextBox.TabIndex = 24;
      this.akbitTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numberTextBox_KeyDown);
      this.akbitTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberTextBox_KeyPress);
      // 
      // vkbitTextBox
      // 
      this.vkbitTextBox.Location = new System.Drawing.Point(121, 72);
      this.vkbitTextBox.MaxLength = 10;
      this.vkbitTextBox.Name = "vkbitTextBox";
      this.vkbitTextBox.Size = new System.Drawing.Size(82, 20);
      this.vkbitTextBox.TabIndex = 23;
      this.vkbitTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numberTextBox_KeyDown);
      this.vkbitTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberTextBox_KeyPress);
      // 
      // vwidthTextBox
      // 
      this.vwidthTextBox.Location = new System.Drawing.Point(84, 149);
      this.vwidthTextBox.MaxLength = 6;
      this.vwidthTextBox.Name = "vwidthTextBox";
      this.vwidthTextBox.Size = new System.Drawing.Size(119, 20);
      this.vwidthTextBox.TabIndex = 22;
      this.vwidthTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numberTextBox_KeyDown);
      this.vwidthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberTextBox_KeyPress);
      // 
      // vheightTextBox
      // 
      this.vheightTextBox.Location = new System.Drawing.Point(84, 123);
      this.vheightTextBox.MaxLength = 6;
      this.vheightTextBox.Name = "vheightTextBox";
      this.vheightTextBox.Size = new System.Drawing.Size(119, 20);
      this.vheightTextBox.TabIndex = 21;
      this.vheightTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numberTextBox_KeyDown);
      this.vheightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberTextBox_KeyPress);
      // 
      // acodecComboBox
      // 
      this.acodecComboBox.FormattingEnabled = true;
      this.acodecComboBox.Location = new System.Drawing.Point(91, 190);
      this.acodecComboBox.Name = "acodecComboBox";
      this.acodecComboBox.Size = new System.Drawing.Size(112, 21);
      this.acodecComboBox.TabIndex = 20;
      // 
      // vcodecComboBox
      // 
      this.vcodecComboBox.FormattingEnabled = true;
      this.vcodecComboBox.Location = new System.Drawing.Point(91, 45);
      this.vcodecComboBox.Name = "vcodecComboBox";
      this.vcodecComboBox.Size = new System.Drawing.Size(112, 21);
      this.vcodecComboBox.TabIndex = 19;
      // 
      // resizeVidCheckBox
      // 
      this.resizeVidCheckBox.AutoSize = true;
      this.resizeVidCheckBox.Location = new System.Drawing.Point(9, 100);
      this.resizeVidCheckBox.Name = "resizeVidCheckBox";
      this.resizeVidCheckBox.Size = new System.Drawing.Size(88, 17);
      this.resizeVidCheckBox.TabIndex = 14;
      this.resizeVidCheckBox.Text = "Resize Video";
      this.resizeVidCheckBox.UseVisualStyleBackColor = true;
      this.resizeVidCheckBox.CheckedChanged += new System.EventHandler(this.resizeVidCheckBox_CheckedChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 152);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(72, 13);
      this.label2.TabIndex = 10;
      this.label2.Text = "Video Width*:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 126);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(75, 13);
      this.label1.TabIndex = 9;
      this.label1.Text = "Video Height*:";
      // 
      // akbitLabel
      // 
      this.akbitLabel.AutoSize = true;
      this.akbitLabel.Location = new System.Drawing.Point(6, 220);
      this.akbitLabel.Name = "akbitLabel";
      this.akbitLabel.Size = new System.Drawing.Size(109, 13);
      this.akbitLabel.TabIndex = 6;
      this.akbitLabel.Text = "Audio Bitrate (kb/s)**:";
      // 
      // vkbitLabel
      // 
      this.vkbitLabel.AutoSize = true;
      this.vkbitLabel.Location = new System.Drawing.Point(6, 75);
      this.vkbitLabel.Name = "vkbitLabel";
      this.vkbitLabel.Size = new System.Drawing.Size(109, 13);
      this.vkbitLabel.TabIndex = 5;
      this.vkbitLabel.Text = "Video Bitrate (kb/s)**:";
      // 
      // acodecLabel
      // 
      this.acodecLabel.AutoSize = true;
      this.acodecLabel.Location = new System.Drawing.Point(6, 194);
      this.acodecLabel.Name = "acodecLabel";
      this.acodecLabel.Size = new System.Drawing.Size(79, 13);
      this.acodecLabel.TabIndex = 2;
      this.acodecLabel.Text = "Audio Codec**:";
      // 
      // vcodecLabel
      // 
      this.vcodecLabel.AutoSize = true;
      this.vcodecLabel.Location = new System.Drawing.Point(6, 49);
      this.vcodecLabel.Name = "vcodecLabel";
      this.vcodecLabel.Size = new System.Drawing.Size(79, 13);
      this.vcodecLabel.TabIndex = 1;
      this.vcodecLabel.Text = "Video Codec**:";
      // 
      // fileOptionsGroupBox
      // 
      this.fileOptionsGroupBox.Controls.Add(this.newFileSuffixTextBox);
      this.fileOptionsGroupBox.Controls.Add(this.newFilePrefixTextBox);
      this.fileOptionsGroupBox.Controls.Add(this.label4);
      this.fileOptionsGroupBox.Controls.Add(this.label3);
      this.fileOptionsGroupBox.Location = new System.Drawing.Point(6, 436);
      this.fileOptionsGroupBox.Name = "fileOptionsGroupBox";
      this.fileOptionsGroupBox.Size = new System.Drawing.Size(311, 81);
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
      // specTabPage
      // 
      this.specTabPage.AutoScroll = true;
      this.specTabPage.Controls.Add(this.x264GroupBox);
      this.specTabPage.Location = new System.Drawing.Point(4, 22);
      this.specTabPage.Name = "specTabPage";
      this.specTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.specTabPage.Size = new System.Drawing.Size(340, 377);
      this.specTabPage.TabIndex = 1;
      this.specTabPage.Text = "Codec Specific";
      this.specTabPage.UseVisualStyleBackColor = true;
      // 
      // x264GroupBox
      // 
      this.x264GroupBox.Controls.Add(this.x264advancedGroupBox);
      this.x264GroupBox.Controls.Add(this.label18);
      this.x264GroupBox.Controls.Add(this.x264crfTextBox);
      this.x264GroupBox.Controls.Add(this.label11);
      this.x264GroupBox.Controls.Add(this.x264presetComboBox);
      this.x264GroupBox.Controls.Add(this.x264tuneComboBox);
      this.x264GroupBox.Controls.Add(this.label10);
      this.x264GroupBox.Controls.Add(this.label9);
      this.x264GroupBox.Controls.Add(this.label8);
      this.x264GroupBox.Location = new System.Drawing.Point(6, 7);
      this.x264GroupBox.Name = "x264GroupBox";
      this.x264GroupBox.Size = new System.Drawing.Size(328, 234);
      this.x264GroupBox.TabIndex = 14;
      this.x264GroupBox.TabStop = false;
      this.x264GroupBox.Text = "x264 Options";
      // 
      // x264crfTextBox
      // 
      this.x264crfTextBox.Location = new System.Drawing.Point(78, 19);
      this.x264crfTextBox.MaxLength = 2;
      this.x264crfTextBox.Name = "x264crfTextBox";
      this.x264crfTextBox.Size = new System.Drawing.Size(42, 20);
      this.x264crfTextBox.TabIndex = 8;
      this.x264crfTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numberTextBox_KeyDown);
      this.x264crfTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberTextBox_KeyPress);
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Enabled = false;
      this.label11.Location = new System.Drawing.Point(3, 214);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(140, 13);
      this.label11.TabIndex = 7;
      this.label11.Text = "More options coming soon...";
      // 
      // x264hi10CheckBox
      // 
      this.x264hi10CheckBox.AutoSize = true;
      this.x264hi10CheckBox.Enabled = false;
      this.x264hi10CheckBox.Location = new System.Drawing.Point(9, 44);
      this.x264hi10CheckBox.Name = "x264hi10CheckBox";
      this.x264hi10CheckBox.Size = new System.Drawing.Size(111, 17);
      this.x264hi10CheckBox.TabIndex = 6;
      this.x264hi10CheckBox.Text = "Enable Hi10 h264";
      this.x264hi10CheckBox.UseVisualStyleBackColor = true;
      // 
      // x264presetComboBox
      // 
      this.x264presetComboBox.FormattingEnabled = true;
      this.x264presetComboBox.Location = new System.Drawing.Point(78, 45);
      this.x264presetComboBox.Name = "x264presetComboBox";
      this.x264presetComboBox.Size = new System.Drawing.Size(121, 21);
      this.x264presetComboBox.TabIndex = 4;
      // 
      // x264tuneComboBox
      // 
      this.x264tuneComboBox.FormattingEnabled = true;
      this.x264tuneComboBox.Location = new System.Drawing.Point(78, 72);
      this.x264tuneComboBox.Name = "x264tuneComboBox";
      this.x264tuneComboBox.Size = new System.Drawing.Size(121, 21);
      this.x264tuneComboBox.TabIndex = 3;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(6, 75);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(35, 13);
      this.label10.TabIndex = 2;
      this.label10.Text = "Tune:";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(6, 48);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(65, 13);
      this.label9.TabIndex = 1;
      this.label9.Text = "x264 preset:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(6, 22);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(31, 13);
      this.label8.TabIndex = 0;
      this.label8.Text = "CRF:";
      // 
      // subsTabPage
      // 
      this.subsTabPage.Controls.Add(this.subIndexTextBox);
      this.subsTabPage.Controls.Add(this.extSubFormatComboBox);
      this.subsTabPage.Controls.Add(this.label16);
      this.subsTabPage.Controls.Add(this.label14);
      this.subsTabPage.Controls.Add(this.subsFilterCheckBox);
      this.subsTabPage.Controls.Add(this.extSubCheckBox);
      this.subsTabPage.Location = new System.Drawing.Point(4, 22);
      this.subsTabPage.Name = "subsTabPage";
      this.subsTabPage.Size = new System.Drawing.Size(340, 377);
      this.subsTabPage.TabIndex = 4;
      this.subsTabPage.Text = "Subtitles";
      this.subsTabPage.UseVisualStyleBackColor = true;
      // 
      // subIndexTextBox
      // 
      this.subIndexTextBox.Location = new System.Drawing.Point(102, 85);
      this.subIndexTextBox.MaxLength = 2;
      this.subIndexTextBox.Name = "subIndexTextBox";
      this.subIndexTextBox.Size = new System.Drawing.Size(49, 20);
      this.subIndexTextBox.TabIndex = 8;
      this.subIndexTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numberTextBox_KeyDown);
      this.subIndexTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberTextBox_KeyPress);
      // 
      // extSubFormatComboBox
      // 
      this.extSubFormatComboBox.FormattingEnabled = true;
      this.extSubFormatComboBox.Location = new System.Drawing.Point(148, 27);
      this.extSubFormatComboBox.Name = "extSubFormatComboBox";
      this.extSubFormatComboBox.Size = new System.Drawing.Size(75, 21);
      this.extSubFormatComboBox.TabIndex = 5;
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Location = new System.Drawing.Point(21, 30);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(121, 13);
      this.label16.TabIndex = 4;
      this.label16.Text = "External Subtitle Format:";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(21, 88);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(74, 13);
      this.label14.TabIndex = 2;
      this.label14.Text = "Subtitle Index:";
      // 
      // subsFilterCheckBox
      // 
      this.subsFilterCheckBox.AutoSize = true;
      this.subsFilterCheckBox.Location = new System.Drawing.Point(3, 61);
      this.subsFilterCheckBox.Name = "subsFilterCheckBox";
      this.subsFilterCheckBox.Size = new System.Drawing.Size(204, 17);
      this.subsFilterCheckBox.TabIndex = 1;
      this.subsFilterCheckBox.Text = "Use subtitle video filter (Burn subtitles)";
      this.subsFilterCheckBox.UseVisualStyleBackColor = true;
      this.subsFilterCheckBox.CheckedChanged += new System.EventHandler(this.subsFilterCheckBox_CheckedChanged);
      // 
      // extSubCheckBox
      // 
      this.extSubCheckBox.AutoSize = true;
      this.extSubCheckBox.Location = new System.Drawing.Point(3, 7);
      this.extSubCheckBox.Name = "extSubCheckBox";
      this.extSubCheckBox.Size = new System.Drawing.Size(133, 17);
      this.extSubCheckBox.TabIndex = 0;
      this.extSubCheckBox.Text = "Create external subtitle";
      this.extSubCheckBox.UseVisualStyleBackColor = true;
      this.extSubCheckBox.CheckedChanged += new System.EventHandler(this.extSubCheckBox_CheckedChanged);
      // 
      // advancedTabPage
      // 
      this.advancedTabPage.AutoScroll = true;
      this.advancedTabPage.Controls.Add(this.groupBox3);
      this.advancedTabPage.Controls.Add(this.groupBox2);
      this.advancedTabPage.Controls.Add(this.groupBox1);
      this.advancedTabPage.Location = new System.Drawing.Point(4, 22);
      this.advancedTabPage.Name = "advancedTabPage";
      this.advancedTabPage.Size = new System.Drawing.Size(340, 377);
      this.advancedTabPage.TabIndex = 3;
      this.advancedTabPage.Text = "Advanced";
      this.advancedTabPage.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label5);
      this.groupBox2.Controls.Add(this.shutdownCheckBox);
      this.groupBox2.Controls.Add(this.vidScalerComboBox);
      this.groupBox2.Location = new System.Drawing.Point(6, 7);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(311, 100);
      this.groupBox2.TabIndex = 11;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Advanced General";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 25);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(116, 13);
      this.label5.TabIndex = 1;
      this.label5.Text = "Video Scaler Algorithm:";
      // 
      // shutdownCheckBox
      // 
      this.shutdownCheckBox.AutoSize = true;
      this.shutdownCheckBox.Location = new System.Drawing.Point(9, 52);
      this.shutdownCheckBox.Name = "shutdownCheckBox";
      this.shutdownCheckBox.Size = new System.Drawing.Size(251, 17);
      this.shutdownCheckBox.TabIndex = 0;
      this.shutdownCheckBox.Text = "Shutdown after conversion tasks are completed";
      this.shutdownCheckBox.UseVisualStyleBackColor = true;
      // 
      // vidScalerComboBox
      // 
      this.vidScalerComboBox.FormattingEnabled = true;
      this.vidScalerComboBox.Location = new System.Drawing.Point(128, 22);
      this.vidScalerComboBox.Name = "vidScalerComboBox";
      this.vidScalerComboBox.Size = new System.Drawing.Size(121, 21);
      this.vidScalerComboBox.TabIndex = 9;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label13);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.custFFmpegTextBox);
      this.groupBox1.Controls.Add(this.custMapOptionsTextBox);
      this.groupBox1.Controls.Add(this.label7);
      this.groupBox1.Controls.Add(this.label12);
      this.groupBox1.Controls.Add(this.custVidFilterTextBox);
      this.groupBox1.Location = new System.Drawing.Point(6, 113);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(311, 309);
      this.groupBox1.TabIndex = 10;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Manual Options";
      // 
      // label13
      // 
      this.label13.Location = new System.Drawing.Point(18, 20);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(254, 31);
      this.label13.TabIndex = 9;
      this.label13.Text = "Note: Providing manual options here will override all respective options in previ" +
    "ous pages.";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 60);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(123, 13);
      this.label6.TabIndex = 2;
      this.label6.Text = "Custom FFmpeg options:";
      // 
      // custFFmpegTextBox
      // 
      this.custFFmpegTextBox.Location = new System.Drawing.Point(9, 76);
      this.custFFmpegTextBox.Multiline = true;
      this.custFFmpegTextBox.Name = "custFFmpegTextBox";
      this.custFFmpegTextBox.Size = new System.Drawing.Size(283, 50);
      this.custFFmpegTextBox.TabIndex = 3;
      // 
      // custMapOptionsTextBox
      // 
      this.custMapOptionsTextBox.Location = new System.Drawing.Point(9, 237);
      this.custMapOptionsTextBox.Multiline = true;
      this.custMapOptionsTextBox.Name = "custMapOptionsTextBox";
      this.custMapOptionsTextBox.Size = new System.Drawing.Size(283, 50);
      this.custMapOptionsTextBox.TabIndex = 8;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(6, 138);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(137, 13);
      this.label7.TabIndex = 4;
      this.label7.Text = "Custom Video Filter options:";
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(6, 221);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(126, 13);
      this.label12.TabIndex = 7;
      this.label12.Text = "Custom Mapping options:";
      // 
      // custVidFilterTextBox
      // 
      this.custVidFilterTextBox.Location = new System.Drawing.Point(9, 154);
      this.custVidFilterTextBox.Multiline = true;
      this.custVidFilterTextBox.Name = "custVidFilterTextBox";
      this.custVidFilterTextBox.Size = new System.Drawing.Size(283, 50);
      this.custVidFilterTextBox.TabIndex = 5;
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(373, 16);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(123, 23);
      this.okButton.TabIndex = 1;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.okButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Location = new System.Drawing.Point(373, 45);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(123, 23);
      this.cancelButton.TabIndex = 2;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // defaultButton
      // 
      this.defaultButton.Location = new System.Drawing.Point(373, 74);
      this.defaultButton.Name = "defaultButton";
      this.defaultButton.Size = new System.Drawing.Size(123, 23);
      this.defaultButton.TabIndex = 3;
      this.defaultButton.Text = "Restore Defaults";
      this.defaultButton.UseVisualStyleBackColor = true;
      this.defaultButton.Click += new System.EventHandler(this.defaultButton_Click);
      // 
      // label15
      // 
      this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label15.Location = new System.Drawing.Point(21, 268);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(243, 32);
      this.label15.TabIndex = 4;
      this.label15.Text = "*: Must not be empty\r\n**: Empty means use default value for the option";
      // 
      // formatLabel
      // 
      this.formatLabel.AutoSize = true;
      this.formatLabel.Location = new System.Drawing.Point(6, 21);
      this.formatLabel.Name = "formatLabel";
      this.formatLabel.Size = new System.Drawing.Size(42, 13);
      this.formatLabel.TabIndex = 25;
      this.formatLabel.Text = "Format:";
      // 
      // formatComboBox
      // 
      this.formatComboBox.FormattingEnabled = true;
      this.formatComboBox.Location = new System.Drawing.Point(54, 18);
      this.formatComboBox.Name = "formatComboBox";
      this.formatComboBox.Size = new System.Drawing.Size(73, 21);
      this.formatComboBox.TabIndex = 26;
      // 
      // h264profileComboBox
      // 
      this.h264profileComboBox.FormattingEnabled = true;
      this.h264profileComboBox.Location = new System.Drawing.Point(78, 17);
      this.h264profileComboBox.Name = "h264profileComboBox";
      this.h264profileComboBox.Size = new System.Drawing.Size(121, 21);
      this.h264profileComboBox.TabIndex = 10;
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Location = new System.Drawing.Point(6, 20);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(65, 13);
      this.label17.TabIndex = 9;
      this.label17.Text = "h264 profile:";
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.experAudCodecCheckBox);
      this.groupBox3.Location = new System.Drawing.Point(6, 428);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(311, 100);
      this.groupBox3.TabIndex = 12;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Experimental";
      // 
      // experAudCodecCheckBox
      // 
      this.experAudCodecCheckBox.AutoSize = true;
      this.experAudCodecCheckBox.Enabled = false;
      this.experAudCodecCheckBox.Location = new System.Drawing.Point(9, 19);
      this.experAudCodecCheckBox.Name = "experAudCodecCheckBox";
      this.experAudCodecCheckBox.Size = new System.Drawing.Size(177, 17);
      this.experAudCodecCheckBox.TabIndex = 1;
      this.experAudCodecCheckBox.Text = "Use Experimental Audio Codecs";
      this.experAudCodecCheckBox.UseVisualStyleBackColor = true;
      // 
      // label18
      // 
      this.label18.AutoSize = true;
      this.label18.Location = new System.Drawing.Point(124, 22);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(204, 13);
      this.label18.TabIndex = 11;
      this.label18.Text = "- Note: This will ignore video bitrate option";
      // 
      // x264advancedGroupBox
      // 
      this.x264advancedGroupBox.Controls.Add(this.label17);
      this.x264advancedGroupBox.Controls.Add(this.h264profileComboBox);
      this.x264advancedGroupBox.Controls.Add(this.x264hi10CheckBox);
      this.x264advancedGroupBox.Location = new System.Drawing.Point(6, 99);
      this.x264advancedGroupBox.Name = "x264advancedGroupBox";
      this.x264advancedGroupBox.Size = new System.Drawing.Size(316, 100);
      this.x264advancedGroupBox.TabIndex = 13;
      this.x264advancedGroupBox.TabStop = false;
      this.x264advancedGroupBox.Text = "Advanced";
      // 
      // OptionsConvertWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(510, 435);
      this.Controls.Add(this.defaultButton);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "OptionsConvertWindow";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "General Convert Options";
      this.Load += new System.EventHandler(this.OptionsConvertWindow_Load);
      this.panel1.ResumeLayout(false);
      this.tabControl1.ResumeLayout(false);
      this.generalTabPage.ResumeLayout(false);
      this.mappingGroupBox.ResumeLayout(false);
      this.mappingGroupBox.PerformLayout();
      this.generalGroupBox.ResumeLayout(false);
      this.generalGroupBox.PerformLayout();
      this.fileOptionsGroupBox.ResumeLayout(false);
      this.fileOptionsGroupBox.PerformLayout();
      this.specTabPage.ResumeLayout(false);
      this.x264GroupBox.ResumeLayout(false);
      this.x264GroupBox.PerformLayout();
      this.subsTabPage.ResumeLayout(false);
      this.subsTabPage.PerformLayout();
      this.advancedTabPage.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.x264advancedGroupBox.ResumeLayout(false);
      this.x264advancedGroupBox.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.GroupBox generalGroupBox;
    private System.Windows.Forms.GroupBox fileOptionsGroupBox;
    private System.Windows.Forms.TextBox newFilePrefixTextBox;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button defaultButton;
    private System.Windows.Forms.TextBox newFileSuffixTextBox;
    private System.Windows.Forms.Label akbitLabel;
    private System.Windows.Forms.Label vkbitLabel;
    private System.Windows.Forms.Label acodecLabel;
    private System.Windows.Forms.Label vcodecLabel;
    private System.Windows.Forms.GroupBox x264GroupBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox resizeVidCheckBox;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage generalTabPage;
    private System.Windows.Forms.TabPage specTabPage;
    private System.Windows.Forms.TabPage advancedTabPage;
    private System.Windows.Forms.TabPage subsTabPage;
    private System.Windows.Forms.CheckBox subsFilterCheckBox;
    private System.Windows.Forms.CheckBox extSubCheckBox;
    private System.Windows.Forms.CheckBox shutdownCheckBox;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox custFFmpegTextBox;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox custVidFilterTextBox;
    private System.Windows.Forms.ComboBox x264presetComboBox;
    private System.Windows.Forms.ComboBox x264tuneComboBox;
    private System.Windows.Forms.GroupBox mappingGroupBox;
    private System.Windows.Forms.CheckBox incAttSCheckBox;
    private System.Windows.Forms.CheckBox incSubSCheckBox;
    private System.Windows.Forms.CheckBox incAudSCheckBox;
    private System.Windows.Forms.CheckBox incVidSCheckBox;
    private System.Windows.Forms.ComboBox vcodecComboBox;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.CheckBox x264hi10CheckBox;
    private System.Windows.Forms.TextBox custMapOptionsTextBox;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.ComboBox acodecComboBox;
    private System.Windows.Forms.ComboBox vidScalerComboBox;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.ComboBox extSubFormatComboBox;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.TextBox akbitTextBox;
    private System.Windows.Forms.TextBox vkbitTextBox;
    private System.Windows.Forms.TextBox vwidthTextBox;
    private System.Windows.Forms.TextBox vheightTextBox;
    private System.Windows.Forms.TextBox x264crfTextBox;
    private System.Windows.Forms.TextBox subIndexTextBox;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.ComboBox formatComboBox;
    private System.Windows.Forms.Label formatLabel;
    private System.Windows.Forms.ComboBox h264profileComboBox;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.CheckBox experAudCodecCheckBox;
    private System.Windows.Forms.GroupBox x264advancedGroupBox;
  }
}