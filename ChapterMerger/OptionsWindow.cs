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
using System.Text.RegularExpressions;

namespace ChapterMerger
{
  public partial class OptionsWindow : Form
  {

    Configure defaultConf = new Configure();

    private OptionsConvertWindow convertOptionDialog = new OptionsConvertWindow();

    public OptionsWindow()
    {
      InitializeComponent();
    }

  //OptionsWindow OnLoad
    private void OptionsWindow_Load(object sender, EventArgs e)
    {
      InitializeConfiguration(Config.Configure);

      this.convOptionButton.Enabled = Program.hasFFmpeg;

    }

    private void okButton_Click(object sender, EventArgs e)
    {

      //Match match = Regex.Match(this.newFileSuffixTextBox.Text, @"^[\w\- _]*$");
      Match match = Regex.Match(this.newFileSuffixTextBox.Text, @"[<>\|\\/\?\*\:""]+");
      Match match2 = Regex.Match(this.newFilePrefixTextBox.Text, @"[<>\|\\/\?\*\:""]+");

      if (match.Success | match2.Success)
      {
        MessageBox.Show("Invalid characters found in Output File Naming.", "Error");
        return;
      }

      Config.Configure.splitModeTimeStart = this.timeStartRadioButton.Checked;
      Config.Configure.splitModeTimeEnd = this.timeEndRadioButton.Checked;
      Config.Configure.diagnoseChapterinfoDump = this.dumpChapterInfoCheckBox.Checked;
      Config.Configure.diagnoseMkvinfoDump = this.dumpChapterInfoCheckBox.Checked;
      Config.Configure.newfilesuffix = this.newFileSuffixTextBox.Text;
      Config.Configure.newfileprefix = this.newFilePrefixTextBox.Text;
      Config.Configure.noChapterOutput = this.noChapterCheckBox.Checked;
      Config.Configure.sourceOutputFolder = this.sourceOutputCheckBox.Checked;
      Config.Configure.alwaysMerge = this.alwaysMergeCheckBox.Checked;
      Config.Configure.projectIncludeFileList = this.projectIncludeFileListCheckBox.Checked;

      Config.writeConfiguration();

      this.Close();
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void defaultButton_Click(object sender, EventArgs e)
    {
      InitializeConfiguration(defaultConf);
    }

    private void InitializeConfiguration(Configure Configure)
    {
      this.newFileSuffixTextBox.Text = Configure.newfilesuffix;
      this.newFilePrefixTextBox.Text = Configure.newfileprefix;
      this.sourceOutputCheckBox.Checked = Configure.sourceOutputFolder;
      this.alwaysMergeCheckBox.Checked = Configure.alwaysMerge;
      this.projectIncludeFileListCheckBox.Checked = Configure.projectIncludeFileList;
      this.dumpInfoCheckBox.Checked = Configure.diagnoseMkvinfoDump;
      this.dumpChapterInfoCheckBox.Checked = Configure.diagnoseChapterinfoDump;
      this.noChapterCheckBox.Checked = Configure.noChapterOutput;
      if (Configure.splitModeTimeEnd)
        this.timeEndRadioButton.Checked = Configure.splitModeTimeEnd;
      else if (Configure.splitModeTimeStart)
        this.timeStartRadioButton.Checked = Configure.splitModeTimeStart;

    }

    private void convOptionButton_Click(object sender, EventArgs e)
    {
      convertOptionDialog.ShowDialog();
    }
  
  }
}
