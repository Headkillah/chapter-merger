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
  public partial class OptionsConvertWindow : Form
  {

    ConvertConfigure defaultConf = new ConvertConfigure();
    ConvertConfigure thisConf;
    //string vkbitTextBoxOldText = "";
    private bool nonValidEntered = false;
    string originalText;

    public OptionsConvertWindow()
    {
      InitializeComponent();

      foreach (VideoFormats format in Enum.GetValues(typeof(VideoFormats)))
      {
        this.formatComboBox.Items.Add(format.ToString());
      }

      foreach (AudioFormats format in Enum.GetValues(typeof(AudioFormats)))
      {
        this.formatComboBox.Items.Add(format.ToString());
      }

      foreach (SubtitleFormats subs in Enum.GetValues(typeof(SubtitleFormats)))
      {
        this.extSubFormatComboBox.Items.Add(subs.ToString());
        this.formatComboBox.Items.Add(subs.ToString());
      }

      foreach (VideoCodecs vcodec in Enum.GetValues(typeof(VideoCodecs)))
      {
        this.vcodecComboBox.Items.Add(vcodec.ToString());
      }

      foreach (AudioCodecs acodec in Enum.GetValues(typeof(AudioCodecs)))
      {
        this.acodecComboBox.Items.Add(acodec.ToString());
      }

      foreach (X264Presets x264 in Enum.GetValues(typeof(X264Presets)))
      {
        this.x264presetComboBox.Items.Add(x264.ToString());
      }

      foreach (X264Tunes x264 in Enum.GetValues(typeof(X264Tunes)))
      {
        this.x264tuneComboBox.Items.Add(x264.ToString());
      }

      foreach (X264Profiles x264 in Enum.GetValues(typeof(X264Profiles)))
      {
        this.h264profileComboBox.Items.Add(x264.ToString());
      }

      foreach (VideoScalerAlgorithms scale in Enum.GetValues(typeof(VideoScalerAlgorithms)))
      {
        this.vidScalerComboBox.Items.Add(scale.ToString());
      }

      foreach (LanguageCodes lang in Enum.GetValues(typeof(LanguageCodes)))
      {
        this.langCodeComboBox.Items.Add(lang);
      }

      string[] h264level = {
                             "3.0",
                             "3.1",
                             "4.0",
                             "4.1",
                             "4.2"
                           };

      foreach (string level in h264level)
        this.x264levelComboBox.Items.Add(level);

    }

  //OptionsWindow OnLoad
    private void OptionsConvertWindow_Load(object sender, EventArgs e)
    {
      InitializeConfiguration(Config.Configure.ConvertConfigure);

      //Removed checking of hasFFmpeg as it is no longer necessary.
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      thisConf = Config.Configure.ConvertConfigure;

      //Match match = Regex.Match(this.newFileSuffixTextBox.Text, @"^[\w\- _]*$");
      Match match = Regex.Match(this.newFileSuffixTextBox.Text, @"[<>\|\\/\?\*\:""]+");
      Match match2 = Regex.Match(this.newFilePrefixTextBox.Text, @"[<>\|\\/\?\*\:""]+");

      if (match.Success | match2.Success)
      {
        MessageBox.Show("Invalid characters found in Output File Naming.", "Error");
        return;
      }

      if (custVFilterTextBox.Text.Contains('-'))
      {
        MessageBox.Show("Custom VFilter must not contain dashes.", "Error");
        return;
      }

      if (custMapTextBox.Text.Contains(' '))
      {
        MessageBox.Show("Custom Mapping must not contain spaces.", "Error");
        return;
      }
      
      thisConf.newfilesuffix = this.newFileSuffixTextBox.Text;
      thisConf.newfileprefix = this.newFilePrefixTextBox.Text;

      thisConf.format = this.formatComboBox.Text;
      thisConf.acodec = this.acodecComboBox.Text;
      thisConf.vcodec = this.vcodecComboBox.Text;
      thisConf.audiobitkb = int.Parse(this.akbitTextBox.Text);
      thisConf.videobitkb = int.Parse(this.vkbitTextBox.Text);
      thisConf.vheight = int.Parse(this.vheightTextBox.Text);
      thisConf.vwidth = int.Parse(this.vwidthTextBox.Text);
      thisConf.x264crf = int.Parse(this.x264crfTextBox.Text);
      thisConf.x264preset = this.x264presetComboBox.Text;
      thisConf.x264tune = this.x264tuneComboBox.Text;
      thisConf.externalsubs = this.extSubCheckBox.Checked;
      thisConf.externalsubsext = this.extSubFormatComboBox.Text;
      thisConf.useSubFilter = this.subsFilterCheckBox.Checked;
      thisConf.subindex = int.Parse(this.subIndexTextBox.Text);

      thisConf.shutdownDevice = this.shutdownCheckBox.Checked;
      thisConf.showCommands = this.showMessageBoxCheckBox.Checked;  //Added for diagnostics
      thisConf.showFFmpegWindow = this.showFFmpegCheckBox.Checked;  //Added for diagnostics

      thisConf.vscaler = this.vidScalerComboBox.Text;
      thisConf.customffmpegarg = this.custFFmpegTextBox.Text;

      thisConf.x264faststart = this.x264fastStartCheckBox.Checked;
      thisConf.x264level = this.x264levelComboBox.Text;
      thisConf.x264pretest = this.x264pretestCheckBox.Checked;
      thisConf.x264offsettime = int.Parse(this.x264offsetTextBox.Text);
      thisConf.x264outduration = int.Parse(this.x264durationTextBox.Text);
      thisConf.usex264opts = this.x264optsCheckBox.Checked;
      thisConf.x264optsarg = this.x264optsTextBox.Text;
      thisConf.x264fps = this.x264fpsTextBox.Text;
      thisConf.x264profile = this.h264profileComboBox.Text;
      thisConf.customx264arg = this.customx264TextBox.Text;
      thisConf.custommapping = this.custMapTextBox.Text;
      thisConf.customvfilter = this.custVFilterTextBox.Text;
      thisConf.audiochannel = int.Parse(this.audchannelTextBox.Text);
      thisConf.audlangswitch = this.audLangSwitchCheckBox.Checked;
      thisConf.alanguage = this.langCodeComboBox.Text;

      thisConf.vresize = this.resizeVidCheckBox.Checked;
      thisConf.maintainAspectRatio = this.maintainAspectCheckBox.Checked;

      thisConf.includeVidStreams = this.incVidSCheckBox.Checked;
      thisConf.includeAudStreams = this.incAudSCheckBox.Checked;
      thisConf.includeSubStreams = this.incSubSCheckBox.Checked;
      thisConf.includeAttStreams = this.incAttSCheckBox.Checked;

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

    private void InitializeConfiguration(ConvertConfigure ConvertConfigure)
    {

      this.newFileSuffixTextBox.Text = ConvertConfigure.newfilesuffix;
      this.newFilePrefixTextBox.Text = ConvertConfigure.newfileprefix;

      this.formatComboBox.Text = ConvertConfigure.format;
      this.acodecComboBox.Text = ConvertConfigure.acodec;
      this.vcodecComboBox.Text = ConvertConfigure.vcodec;
      this.akbitTextBox.Text = ConvertConfigure.audiobitkb.ToString();
      this.vkbitTextBox.Text = ConvertConfigure.videobitkb.ToString();
      this.vheightTextBox.Text = ConvertConfigure.vheight.ToString();
      this.vwidthTextBox.Text = ConvertConfigure.vwidth.ToString();
      this.x264crfTextBox.Text = ConvertConfigure.x264crf.ToString();
      this.x264presetComboBox.Text = ConvertConfigure.x264preset;
      this.x264tuneComboBox.Text = ConvertConfigure.x264tune;
      this.extSubCheckBox.Checked = ConvertConfigure.externalsubs;
      this.extSubFormatComboBox.Text = ConvertConfigure.externalsubsext;
      this.subsFilterCheckBox.Checked = ConvertConfigure.useSubFilter;
      this.subIndexTextBox.Text = ConvertConfigure.subindex.ToString();

      this.shutdownCheckBox.Checked = ConvertConfigure.shutdownDevice;
      this.showMessageBoxCheckBox.Checked = ConvertConfigure.showCommands;  //Added for diagnostics
      this.showFFmpegCheckBox.Checked = ConvertConfigure.showFFmpegWindow;  //Added for diagnostics

      this.vidScalerComboBox.Text = ConvertConfigure.vscaler;
      this.custFFmpegTextBox.Text = ConvertConfigure.customffmpegarg;

      this.x264fastStartCheckBox.Checked = ConvertConfigure.x264faststart;
      this.x264levelComboBox.Text = ConvertConfigure.x264level;
      this.x264pretestCheckBox.Checked = ConvertConfigure.x264pretest;
      this.x264offsetTextBox.Text = ConvertConfigure.x264offsettime.ToString();
      this.x264durationTextBox.Text = ConvertConfigure.x264outduration.ToString();
      this.x264optsCheckBox.Checked = ConvertConfigure.usex264opts;
      this.x264optsTextBox.Text = ConvertConfigure.x264optsarg;
      this.x264fpsTextBox.Text = ConvertConfigure.x264fps.ToString();
      this.h264profileComboBox.Text = ConvertConfigure.x264profile;
      this.customx264TextBox.Text = ConvertConfigure.customx264arg;
      this.custMapTextBox.Text = ConvertConfigure.custommapping;
      this.custVFilterTextBox.Text = ConvertConfigure.customvfilter;
      this.audchannelTextBox.Text = ConvertConfigure.audiochannel.ToString();
      this.audLangSwitchCheckBox.Checked = ConvertConfigure.audlangswitch;
      this.langCodeComboBox.Text = ConvertConfigure.alanguage;

      this.maintainAspectCheckBox.Checked = ConvertConfigure.maintainAspectRatio;

      this.incVidSCheckBox.Checked = ConvertConfigure.includeVidStreams;
      this.incAudSCheckBox.Checked = ConvertConfigure.includeAudStreams;
      this.incSubSCheckBox.Checked = ConvertConfigure.includeSubStreams;
      this.incAttSCheckBox.Checked = ConvertConfigure.includeAttStreams;

      this.vheightTextBox.Enabled = resizeVidCheckBox.Checked;
      this.vwidthTextBox.Enabled = resizeVidCheckBox.Checked;
      this.subIndexTextBox.Enabled = subsFilterCheckBox.Checked;
      this.extSubFormatComboBox.Enabled = extSubCheckBox.Checked;

      if (ConvertConfigure.useSubFilter)
      {
        this.incSubSCheckBox.Checked = false;
        this.incAttSCheckBox.Checked = false;
      }

      this.resizeVidCheckBox.Checked = ConvertConfigure.vresize;
      this.maintainAspectCheckBox.Enabled = resizeVidCheckBox.Checked;

      if (ConvertConfigure.maintainAspectRatio)
        this.vwidthTextBox.Enabled = false;
      else
        this.vwidthTextBox.Enabled = true;

      //Removed x264optsTextBox toggling as it is no longer necessary
      this.x264offsetTextBox.Enabled = x264pretestCheckBox.Checked;
      this.x264durationTextBox.Enabled = x264pretestCheckBox.Checked;
      this.langCodeComboBox.Enabled = audLangSwitchCheckBox.Checked;
    }

    /*
     * Legacy Code
     * 
    private void numberTextBox_TextChanged(object sender, EventArgs e)
    {
      bool textValid = Regex.Match(vkbitTextBox.Text, @"^\d*$").Success;

      if (!textValid)
      {
        MessageBox.Show("Please input numbers only.");
        vkbitTextBox.Text = vkbitTextBoxOldText;
      }
      else
      {
        vkbitTextBoxOldText = vkbitTextBox.Text;
      }
    }
     * 
     * */

  /*
   * Custom Validation for a textbox.
   * 
   * Uses manual validations of keystrokes on the control,
   * whether to show the input on the control after the key press event
   * or not.
   * In this case, only numbers are valid.
   * 
   * Exactly the same as the example in https://msdn.microsoft.com/en-us/library/system.windows.forms.control.keydown(v=vs.110).aspx
   * NOTE: Lame.
   * 
   * This will be used on other text box that require only numbers as input.
   * */
    private void numberTextBox_KeyDown(object sender, KeyEventArgs e)
    {
      // Initialize the flag to false.
      nonValidEntered = false;

      // Determine whether the keystroke is a number from the top of the keyboard. 
      if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
      {
        // Determine whether the keystroke is a number from the keypad. 
        if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
        {
          // Determine whether the keystroke is a backspace. 
          if (e.KeyCode != Keys.Back)
          {
            // A non-numerical keystroke was pressed. 
            // Set the flag to true and evaluate in KeyPress event.
            nonValidEntered = true;
          }
        }
      }
      //If shift key was pressed, it's not a number. 
      if (Control.ModifierKeys == Keys.Shift)
      {
        nonValidEntered = true;
      }
    }

    private void numberTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      // Check for the flag being set in the KeyDown event. 
      if (nonValidEntered == true)
      {
        // Stop the character from being entered into the control since it is non-numerical.
        e.Handled = true;
      }
    }
  /*
   * End of Custom Validation
   * 
   * */

    private void resizeVidCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      this.vheightTextBox.Enabled = resizeVidCheckBox.Checked;
      this.maintainAspectCheckBox.Enabled = resizeVidCheckBox.Checked;
      if (this.maintainAspectCheckBox.Checked)
        this.vwidthTextBox.Enabled = false;
      else
        this.vwidthTextBox.Enabled = true;
    }

    private void extSubCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      this.extSubFormatComboBox.Enabled = extSubCheckBox.Checked;
    }

    private void subsFilterCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      this.subIndexTextBox.Enabled = subsFilterCheckBox.Checked;
      bool invertCheck;
      if (!subsFilterCheckBox.Checked)
        invertCheck = true;
      else
        invertCheck = false;

      this.incAttSCheckBox.Enabled = invertCheck;
      this.incSubSCheckBox.Enabled = invertCheck;
    }

    private void audLangSwitchCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      this.langCodeComboBox.Enabled = audLangSwitchCheckBox.Checked;
    }

    private void x264fpsTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = this.ValidateKeyPress(sender, e, 3).Handled;
    }

    private KeyPressEventArgs ValidateKeyPress(object sender, KeyPressEventArgs e, int mode = 0)
    {

      if (e.KeyChar != (Char)Keys.Back)
      {
        switch (mode)
        {
          case 0:
            if (!Char.IsDigit(e.KeyChar))
              e.Handled = true;
            break;
          case 1:
            if (!Char.IsLetter(e.KeyChar))
              e.Handled = true;
            break;
          case 2:
            if (Char.IsSymbol(e.KeyChar))
              e.Handled = true;
            break;
          case 3:
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '.')
              e.Handled = true;
            break;
          default:
            if (!Char.IsLetterOrDigit(e.KeyChar))
              e.Handled = true;
            break;
        }
      }
      
      return e;

    }

    private void maintainAspectCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      if (maintainAspectCheckBox.Checked)
      {
        originalText = this.vwidthTextBox.Text;
        this.vwidthTextBox.Enabled = false;
        this.vwidthTextBox.Text = "-2";
      }
      else
      {
        if (this.resizeVidCheckBox.Checked)
          this.vwidthTextBox.Enabled = true;
        this.vwidthTextBox.Text = originalText;
      }
    }

    private void x264pretestCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      this.x264offsetTextBox.Enabled = x264pretestCheckBox.Checked;
      this.x264durationTextBox.Enabled = x264pretestCheckBox.Checked;
    }

    private void custVFilterTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == '-')
        e.Handled = true;
    }

    private void custMapTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (Char)Keys.Space)
        e.Handled = true;
    }

    //Removed x264optsCheckBox_CheckedChanged as it is no longer necessary

    private void x264optsTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (Char)Keys.Space)
        e.Handled = true;
    }

    private void framerateTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = this.ValidateKeyPress(sender, e).Handled;
    }

  }
}
