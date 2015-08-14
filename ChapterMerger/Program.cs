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

namespace ChapterMerger
{
  static class Program
  {

    private static string environmentPath = Environment.GetEnvironmentVariable("PATH");
    //public static string thisProgramPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    public static string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public static string mergeExe;
    public static string infoExe;
    public static string ffmpegExe;

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {

      //Config.Initialize();

      mergeExe = Program.getExe("mkvmerge.exe");
      infoExe = Program.getExe("mkvinfo.exe");
      ffmpegExe = Program.getExe("ffmpeg.exe");

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

      if (mergeExe == null | infoExe == null)
      {
        MessageBox.Show("Error: mkvtoolnix not found.\r\n\r\nEither this program must exist inside mkvtoolnix or mkvtoolnix must be included in the PATH Variable.", "Error");
        Environment.Exit(1);
      }

      List<string> programArgs = new List<string>();

    //Dummy command line argument checking. For *future* purposes
      foreach (string s in args)
      {
        if (s == "-g" || s == "--gui")
        {
          Config.Configure.launchGui = true;
        }
        else
        {
          programArgs.Add(s);
        }
      }

      if (Config.Configure.launchGui)
        Program.launchGUI(programArgs.ToArray());

    }

    static void launchGUI(string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainWindow(args));
    }

    /// <summary>
    /// Checks if required external program exist in the PATH variable
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
    /// <returns></returns>
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
  }
}
