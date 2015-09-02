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
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ChapterMerger
{
  static class Program
  {
    
    /// <summary>
    /// Stores the current machine's PATH environment variable's value.
    /// </summary>
    private static string environmentPath = Environment.GetEnvironmentVariable("PATH");

    /// <summary>
    /// The default path used for most file operations. Currently points to the current user's Documents.
    /// </summary>
    public static string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    /// <summary>
    /// The path for mkvmerge.
    /// </summary>
    public static string mergeExe;

    /// <summary>
    /// The path for mkvinfo.
    /// </summary>
    public static string infoExe;

    /// <summary>
    /// The path for ffmpeg.
    /// </summary>
    public static string ffmpegExe;

    /// <summary>
    /// The path for ffprobe.
    /// </summary>
    public static string ffprobeExe;

    /// <summary>
    /// Determines if mkvmerge is present.
    /// </summary>
    public static bool hasMkvMerge = false;

    /// <summary>
    /// Determines if mkvinfo is present.
    /// </summary>
    public static bool hasMkvInfo = false;

    /// <summary>
    /// Determines if ffmpeg is present.
    /// </summary>
    public static bool hasFFmpeg = false;

    /// <summary>
    /// Determines if ffprobe is present.
    /// </summary>
    public static bool hasFFprobe = false;

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {

      //Config.Initialize();

      checkDependencies();  //Grouped the former commands into this new baby.

      if (!hasMkvMerge || !hasMkvInfo)
      {
        MessageBox.Show("Error: mkvtoolnix not found.\r\n\r\nEither this program must exist inside mkvtoolnix or mkvtoolnix must be included in the PATH Variable.", "Error");
        Environment.Exit(1);
      }

      try
      {
        Config.getConfiguration();
      }
      catch
      {
        MessageBox.Show("Configuration file corrupted! Default settings will be loaded.");
        Config.Initialize();
        Config.writeConfiguration();
      }

      List<string> programArgs = new List<string>();

    //Dummy command line argument checking. For *future* purposes
      foreach (string s in args)
      {
        if (s == "-g" || s == "--gui")
        {
          Config.Configure.useGui = true;
        }
        else
        {
          programArgs.Add(s);
        }
      }

      Program.launchGUI(programArgs.ToArray());

    }

    /// <summary>
    /// Launches the ChapterMerger Form.
    /// </summary>
    /// <param name="args"></param>
    static void launchGUI(string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainWindow(args));
    }

    /// <summary>
    /// Checks if an external program exists in the PATH variable
    /// </summary>
    /// <param name="exe">The external program to check.</param>
    /// <returns></returns>
    public static string getEnvPathExe(string exe)
    {

      //if (Config.Configure.diagnose >= 20) Console.WriteLine(environmentPath);
      var paths = environmentPath.Split(';');
      var exePath = paths.Select(x => Path.Combine(x, exe))
                         .Where(x => File.Exists(x))
                         .FirstOrDefault();

      //if (Config.Configure.diagnose >= 20) Console.WriteLine(exePath);

      return exePath;
    }

    /// <summary>
    /// Returns the path of the external program if exists in the current directory or in PATH variable
    /// </summary>
    /// <param name="exe">The external program to check.</param>
    /// <returns>The path of the external program.</returns>
    public static string getExe(string exe)
    {
      string currentDirExe = Path.Combine(Program.defaultPath, exe);
      string envPathExe = getEnvPathExe(exe);

      if (envPathExe != null)
      {
        return envPathExe;
      }
      else if (File.Exists(currentDirExe))
      {
        return currentDirExe;
      }

      return null;
    }

    /// <summary>
    /// Shutdowns the current device (A fancy term.)
    /// </summary>
    public static void ShutdownDevice()
    {
      //Currently for Windows only.

      ProcessStartInfo shutdownInfo = new ProcessStartInfo();

      shutdownInfo.FileName = "shutdown";
      shutdownInfo.Arguments = "-s -t 0";

      Process shutdownProcess = Process.Start(shutdownInfo);
      
    }

    /// <summary>
    /// Checks for the program's current dependencies.
    /// </summary>
    public static void checkDependencies()
    {
      mergeExe = Program.getExe("mkvmerge.exe");
      infoExe = Program.getExe("mkvinfo.exe");
      ffmpegExe = Program.getExe("ffmpeg.exe");
      ffprobeExe = Program.getExe("ffprobe.exe");

      if (!String.IsNullOrWhiteSpace(mergeExe))
        hasMkvMerge = true;
      if (!String.IsNullOrWhiteSpace(infoExe))
        hasMkvInfo = true;
      if (!String.IsNullOrWhiteSpace(ffmpegExe))
        hasFFmpeg = true;
      if (!String.IsNullOrWhiteSpace(ffprobeExe))
        hasFFprobe = true;
    }

    /// <summary>
    /// Show a message informing the user, with GUI or not.
    /// </summary>
    /// <param name="message">The message to show.</param>
    /// <param name="title">The title of the message.</param>
    /// <param name="customDialog">If true, use CustomDialog form.</param>
    /// <param name="button1">The first button text for CustomDialog form.</param>
    /// <param name="button2">The second button text for CustomDialog form.</param>
    /// <param name="button3">The third button text for CustomDialog form.</param>
    public static void Message(string message, string title = "Information", bool customDialog = false, string button1 ="OK", string button2 = "", string button3 = "")
    {
      if (Config.Configure.useGui)
      {
        if (customDialog)
          CustomDialog.Show(message, title, button1, button2, button3);
        else
          MessageBox.Show(message, title);
      }
      else
      {
        Console.WriteLine(title);
      }
    }

    /// <summary>
    /// Checks if file extension is valid for merging/converting.
    /// </summary>
    /// <param name="file">The FileObject to process.</param>
    /// <returns>True if file extension is valid; else, false.</returns>
    public static bool ValidateExtension(FileObject file)
    {
      bool valid = false;

      //Temporary list of extensions; maybe replaced by a more proper global list in the future.
      string[] extensions = {
                              ".mkv",
                              ".mp4",
                              ".mpeg",
                              ".avi",
                              ".wmv",
                              ".aac",
                              ".ogg",
                              ".mp3",
                              ".m4a",
                              ".jpg",
                              ".jpeg",
                              ".png",
                              ".bmp",
                              ".tga"
                            };

      foreach (string extension in MediaData.extensions)
      {
        if (file.extension == extension)
          valid = true;
        else
          valid = false;
      }

      return valid;
    }

  }
}
