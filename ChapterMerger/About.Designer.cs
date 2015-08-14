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
  partial class About
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.licenseGroupBox = new System.Windows.Forms.GroupBox();
      this.licenseTextBox = new System.Windows.Forms.TextBox();
      this.licenseLabel = new System.Windows.Forms.Label();
      this.licenseGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(8, 25);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(224, 25);
      this.label1.TabIndex = 0;
      this.label1.Text = "ChapterMerger Beta";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 59);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(69, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Version 0.9.0";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 72);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(98, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "Author: Mon C.A.S.";
      // 
      // licenseGroupBox
      // 
      this.licenseGroupBox.Controls.Add(this.licenseTextBox);
      this.licenseGroupBox.Controls.Add(this.licenseLabel);
      this.licenseGroupBox.Location = new System.Drawing.Point(13, 97);
      this.licenseGroupBox.Name = "licenseGroupBox";
      this.licenseGroupBox.Size = new System.Drawing.Size(355, 191);
      this.licenseGroupBox.TabIndex = 4;
      this.licenseGroupBox.TabStop = false;
      // 
      // licenseTextBox
      // 
      this.licenseTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.licenseTextBox.Location = new System.Drawing.Point(6, 19);
      this.licenseTextBox.Multiline = true;
      this.licenseTextBox.Name = "licenseTextBox";
      this.licenseTextBox.ReadOnly = true;
      this.licenseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.licenseTextBox.Size = new System.Drawing.Size(343, 165);
      this.licenseTextBox.TabIndex = 1;
      this.licenseTextBox.Text = resources.GetString("licenseTextBox.Text");
      // 
      // licenseLabel
      // 
      this.licenseLabel.AutoSize = true;
      this.licenseLabel.Location = new System.Drawing.Point(109, 0);
      this.licenseLabel.Name = "licenseLabel";
      this.licenseLabel.Size = new System.Drawing.Size(143, 13);
      this.licenseLabel.TabIndex = 0;
      this.licenseLabel.Text = "GNU General Public License";
      // 
      // About
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(380, 300);
      this.Controls.Add(this.licenseGroupBox);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "About";
      this.ShowIcon = false;
      this.Text = "About";
      this.licenseGroupBox.ResumeLayout(false);
      this.licenseGroupBox.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.GroupBox licenseGroupBox;
    private System.Windows.Forms.TextBox licenseTextBox;
    private System.Windows.Forms.Label licenseLabel;
  }
}