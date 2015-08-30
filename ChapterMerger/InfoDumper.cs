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
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace ChapterMerger
{
  class InfoDumper
  {
  /// <summary>
  /// Dumps MKVinfo's of every file for later use
  /// </summary>
  /// <param name="file">The FileObject to process.</param>
  /// <returns>The FileObject processed.</returns>
    public static FileObject infoDump(FileObject file)
    {

      if (file.extension == ".mkv")
      {

        /*
         * Use of using syntax is preferred.
         * Also, hidden window style is preferred.
         * 
         */
        ProcessStartInfo p = new ProcessStartInfo(Program.infoExe);

        p.Arguments = "\"" + file.fullpath + "\"";
        p.UseShellExecute = false;
        p.CreateNoWindow = true;
        p.WindowStyle = ProcessWindowStyle.Hidden;
        p.RedirectStandardOutput = true;
        //Process.Start(p);

        using (Process process = Process.Start(p))
        {
          using (StreamReader reader = process.StandardOutput)
          {
            string output = reader.ReadToEnd();
            file.addMkvInfo(output);

          }
          process.WaitForExit();
        }

      }
      else
      {
        Console.WriteLine("Not an MKV file.");
      }

      return file;

    }

    /// <summary>
    /// Dumps entire media info from FFmpeg output.
    /// </summary>
    /// <param name="file">The FileObject to process.</param>
    /// <returns>The FileObject processed.</returns>
    public static FileObject ffInfoDump(FileObject file)
    {

      ProcessStartInfo p = new ProcessStartInfo(Program.ffmpegExe);

      p.Arguments = "-i \"" + file.fullpath + "\"";
      p.UseShellExecute = false;
      p.CreateNoWindow = true;
      p.WindowStyle = ProcessWindowStyle.Hidden;
      p.RedirectStandardOutput = true;
      p.RedirectStandardError = true;

      using (Process process = Process.Start(p))
      {
        using (StreamReader reader = process.StandardError)
        {
          string output = reader.ReadToEnd();
          file.addFFInfo(output);

        }
        process.WaitForExit();
      }

      return file;

    }

    /// <summary>
    /// Deprecated. Dumps entire media info from FFprobe output.
    /// </summary>
    /// <param name="file">The FileObject to process.</param>
    /// <returns>The FileObject processed.</returns>
    public static FileObject ffProbeDump(FileObject file)
    {

      ProcessStartInfo p = new ProcessStartInfo(Program.ffprobeExe);
      string output = "";

      p.Arguments = "-show_streams -i \"" + file.fullpath + "\"";
      p.UseShellExecute = false;
      p.CreateNoWindow = true;
      p.WindowStyle = ProcessWindowStyle.Hidden;
      p.RedirectStandardOutput = true;
      p.RedirectStandardError = true;

      using (Process process = Process.Start(p))
      {
        /*
        using (StreamReader reader = process.StandardError)
        {
          output = reader.ReadToEnd();
        }
        
        */
        using (StreamReader reader = process.StandardOutput)
        {
          output += reader.ReadToEnd();
        }

        file.addFFInfo(output);

        process.WaitForExit();
      }
      return file;

    }

  }
}
