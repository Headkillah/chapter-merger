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
  public partial class CustomDialog : Form
  {

    /// <summary>
    /// The message of the custom dialog.
    /// </summary>
    string message { get; set; } 

    /// <summary>
    /// The title of the custom dialog.
    /// </summary>
    string title { get; set; }

    /// <summary>
    /// The text of the first button.
    /// </summary>
    string button1Text { get; set; }

    /// <summary>
    /// The text of the second button.
    /// </summary>
    string button2Text { get; set; }
    
    /// <summary>
    /// The text of the third button.
    /// </summary>
    string button3Text { get; set; }

    /// <summary>
    /// The string that represents the button pressed in the custom dialog.
    /// </summary>
    public string buttonPressed { get; private set; }

    public CustomDialog() : this ("Press OK.", "Confirmation", "OK", "", "")
    {
      InitializeComponent();
    }

    /// <summary>
    /// Creates a custom dialog with defined Title, Message, and up to three buttons with at least one button required.
    /// This stores the button pressed in a buttonPressed public field.
    /// </summary>
    /// <param name="message">The message of the custom dialog.</param>
    /// <param name="title">The title of the custom dialog.</param>
    /// <param name="button1Text">Required. The text of the first button.</param>
    /// <param name="button2Text">Optional. The text of the second button.</param>
    /// <param name="button3Text">Optional. The text of the third button.</param>
    public CustomDialog(string message, string title, string button1Text, string button2Text = "", string button3Text = "")
    {
      this.message = message;
      this.title = title;
      this.button1Text = button1Text;
      this.button2Text = button2Text;
      this.button3Text = button3Text;

      InitializeComponent();
    }

    private void CustomDialog_Load(object sender, EventArgs e)
    {
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximumSize = new System.Drawing.Size(480, int.MaxValue);

      InitializeValues();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      buttonPressed = this.button1.Text;
      this.DialogResult = DialogResult.OK;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      buttonPressed = this.button2.Text;
      this.DialogResult = DialogResult.OK;
    }

    private void button3_Click(object sender, EventArgs e)
    {
      buttonPressed = this.button3.Text;
      this.DialogResult = DialogResult.OK;
    }

    /// <summary>
    /// Shows a custom dialog with a new Title, Message, and up to three buttons with at least one button required.
    /// The custom dialog shows the button pressed in a buttonPressed public field.
    /// </summary>
    /// <param name="message">The message of the custom dialog.</param>
    /// <param name="title">The title of the custom dialog.</param>
    /// <param name="button1Text">Required. The text of the first button.</param>
    /// <param name="button2Text">Optional. The text of the second button.</param>
    /// <param name="button3Text">Optional. The text of the third button.</param>
    public static DialogResult Show(string message, string title, string button1Text, string button2Text = "", string button3Text = "")
    {
      CustomDialog customDialog = new CustomDialog(message, title, button1Text, button2Text, button3Text);

      DialogResult result = customDialog.ShowDialog();

      return result;
      
    }

    private void InitializeValues()
    {
      this.Text = title;
      this.label1.Text = message;
      this.button1.Text = button1Text;

      if (!String.IsNullOrWhiteSpace(button2Text))
      {
        this.button2.Text = button2Text;
        this.button2.Show();
      }

      if (!String.IsNullOrWhiteSpace(button3Text))
      {
        this.button3.Text = button3Text;
        this.button3.Show();
      }
    }

  }
}
