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
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ChapterMerger
{

  /// <summary>
  /// Instance that converts media files using FFmpeg, with configuration based from ConvertConfiguration.
  /// </summary>
  class Converter
  {

    /// <summary>
    /// The BackgroundWorker to send reports to.
    /// </summary>
    private System.ComponentModel.BackgroundWorker backgroundWorker;

    /// <summary>
    /// Progress report in raw count.
    /// </summary>
    private int progress;

    /// <summary>
    /// Progress report in percentage.
    /// </summary>
    private int processPercent;

    /// <summary>
    /// The ConvertConfigure instance to get configurations from.
    /// </summary>
    private ConvertConfigure ConvConfig;

    /// <summary>
    /// The string that contains the output path.
    /// </summary>
    private string outputPath = "";

    /// <summary>
    /// Shared FFmpeg arguments.
    /// </summary>
    private string ffmpegOptions = "";

    /// <summary>
    /// List of -vf filter descriptions.
    /// </summary>
    private List<string> vfilters = new List<string>();

    /// <summary>
    /// List of filterchains, with filter descriptions.
    /// Deprecated.
    /// </summary>
    private List<string> filterChains = new List<string>();

    /// <summary>
    /// Stores the current ffmpeg command for external use.
    /// </summary>
    public string currentCommand = "";

    /// <summary>
    /// Create a Converter instance using ConvertConfigure configuration.
    /// </summary>
    /// <param name="ConvConfig">ConvertConfigure instance for Converter configuration.</param>
    public Converter(ConvertConfigure ConvConfig, System.ComponentModel.BackgroundWorker backgroundWorker)
    {
      this.ConvConfig = ConvConfig;
      this.backgroundWorker = backgroundWorker;
    }

    /// <summary>
    /// Main Convert process.
    /// </summary>
    /// <param name="fileList">The FileObjectCollection to process.</param>
    public void Convert(FileObjectCollection fileList, int fileListPercent = 100)
    {

      InitializeConfiguration();

      ProgressState progressState = new ProgressState();
      progressState.listName = fileList.name;

      progress = 1;
      processPercent = 0;

      if (!Config.Configure.sourceOutputFolder)
      {
        outputPath = Program.defaultPath;
        if (!Directory.Exists(Path.Combine(outputPath, "converted")))
          Directory.CreateDirectory(Path.Combine(outputPath, "converted"));
      }

    //Main Loop
      foreach (FileObject file in fileList.fileList)
      {

      //Set Required Variables
        string ffmpegArgs = "";
        string fileVfilter = "";
        string fileVfilterArg = "";
        string fileFFmpegOptions = ffmpegOptions;

        List<string> fileVfilters = new List<string>();
        
        List<string> fileFilterChains = new List<string>();

        foreach (string vfilteritem in vfilters)
          fileVfilters.Add(vfilteritem);

      //Escape Filter Patterns
        string firstLevel = @"([:\\'])";
        string secondLevel = @"([\[\],;\\'])";

      //Input/Output programmatic patterns
        string custInputPat = @"\(inputfile\)";
        string custOutputPat = @"\(outputname\)";

      //Progress Reporting
        progressState.fileName = file.filename;

        processPercent = progress.ToPercentage(fileList.fileList.Count);
        progressState.progressPercent = processPercent;

        progressState.progressDetail = "Building conversion arguments...";
        this.backgroundWorker.ReportProgress(fileListPercent, progressState);

        if (Config.Configure.sourceOutputFolder)
        {
          outputPath = file.directoryname;
        }

        if (!Directory.Exists(Path.Combine(outputPath, "converted")))
          Directory.CreateDirectory(Path.Combine(outputPath, "converted"));

      //Output File Argument
        string outputFile = outputPath + "\\converted\\" + ConvConfig.newfileprefix + file.filenameNoExtension + ConvConfig.newfilesuffix;

      //Fix_subtitle_duration
        if (ConvConfig.fixsubduration)
          ffmpegArgs += @"-fix_sub_duration ";

      //Subtitles
        //Subfilter
        if (ConvConfig.useSubFilter)
        {
        //Escape any special characters
          string fileitem = file.fullpath;
          fileitem = Regex.Replace(fileitem, firstLevel, m =>
          {
            var escapedChars = m.Groups[1].Value;
            return @"\" + escapedChars;
          });

          fileitem = Regex.Replace(fileitem, secondLevel, n =>
          {
            var escapedChars = n.Groups[1].Value;
            return @"\" + escapedChars;
          });

          fileVfilter = @"subtitles=" + fileitem + @":si=" + ConvConfig.subindex.ToString();
          fileVfilters.Add(fileVfilter);
        }

        

      //Video Filter
      //Custom Video Filter
        if (!String.IsNullOrWhiteSpace(ConvConfig.customvfilter))
        {
          fileVfilterArg = ConvConfig.customvfilter;
        }
        else
        {
          //filefilterchain.Add(String.Join(",", vfilters.ToArray()));

          fileVfilterArg = String.Join(", ", fileVfilters.ToArray());
        }

        //Diagnostic purposes only
        //fileVfilterArg = "subtitles=D:\\backup\\anime_archive\\[Coalgirls]_Ookami-san,_to;_Shichinin_no_'Nakama-tachi'_(1280x720_Blu-ray_FLAC)\\[Coalgirls]_Ookami-san_to_Shichinin_no_Nakama-tachi_01_(1280x720_Blu-ray_FLAC)_[F9495BFE].mkv:si=0";

        if (!String.IsNullOrWhiteSpace(fileVfilterArg))
        {
          fileVfilterArg = " -vf \"" + fileVfilterArg + "\"";   //Placeholder
          fileFFmpegOptions += fileVfilterArg;
        }

      //Custom ffmpeg options
        if (!String.IsNullOrWhiteSpace(ConvConfig.customffmpegarg))
        {
          string customData = ConvConfig.customffmpegarg;

          //Replace (inputfile) and (outputname) with input and output variables accordingly.
          customData = Regex.Replace(customData, custInputPat, m => { return file.fullpath; });
          customData = Regex.Replace(customData, custOutputPat, m => { return outputFile; });

          ffmpegArgs = customData;
        }
        else
      //Set final ffmpegArgs
          ffmpegArgs += "-i \"" + file.fullpath + "\"" + fileFFmpegOptions + " \"" + outputFile + "." + ConvConfig.format + "\"";

        currentCommand = ffmpegArgs;

     /*
      * Routine before converting
      * Checks if current backgroundWorker operation is cancelled
      * Stops this program if true
      * 
      * Process cancelling should be changed as this currently waits for previous conversion to complete;
      * Conversion can take a lot of time for cancellation to wait.
      * 
      * Native threading would be used.
      * 
      * */
        if (this.backgroundWorker.CancellationPending)
        {
          return;
        }

        if (ConvConfig.showCommands)
        {
          Program.Message("Current command:\r\n\r\n" + currentCommand, "Diagnostics");
        }

      //Main process
        ProcessStartInfo convertProcess = new ProcessStartInfo();

        convertProcess.FileName = Program.ffmpegExe;
        convertProcess.Arguments = ffmpegArgs;

        convertProcess.UseShellExecute = false;

        if (!Config.Configure.ConvertConfigure.showFFmpegWindow) //Added check for diagnostics
        {
          convertProcess.CreateNoWindow = true;
          convertProcess.WindowStyle = ProcessWindowStyle.Hidden;
          convertProcess.RedirectStandardInput = true;  //Preparation for an eminent interactive ffmpeg thread.
        }
        else
        {
          convertProcess.CreateNoWindow = false;
        }
        convertProcess.WorkingDirectory = file.directoryname;

        progressState.progressDetail = "Converting...";
        this.backgroundWorker.ReportProgress(fileListPercent, progressState);

        using (Process process = Process.Start(convertProcess))
        {
          process.WaitForExit();
        }
          

        //If External subs are set to true.
        if (ConvConfig.externalsubs)
        {
          ffmpegArgs = "-i \"" + file.fullpath + "\" \"" + outputFile + "." + ConvConfig.externalsubsext + "\"";

          currentCommand = ffmpegArgs;

          if (ConvConfig.showCommands)
          {
            Program.Message("Current command:\r\n\r\n" + currentCommand, "Diagnostics");
          }

          convertProcess.Arguments = ffmpegArgs;

          progressState.progressDetail = "Creating external subtitles...";
          this.backgroundWorker.ReportProgress(fileListPercent, progressState);

          using (Process process = Process.Start(convertProcess))
          {
            process.WaitForExit();
          }
          
        }

        progress++;
      //End of Main process
      }

      if (!Analyze.outputGroups.Contains(outputPath))
      {
        Analyze.outputGroups.Add(outputPath + "\\converted");
      }

    }

    /// <summary>
    /// This will build the initial general argument for each file processed to use.
    /// </summary>
    public void InitializeConfiguration()
    {

      //Mapping Options
      //Custom Mapping
      if (!String.IsNullOrWhiteSpace(ConvConfig.custommapping))
      {
        var streamIdentifiers = ConvConfig.custommapping.Split(',');

        foreach (string stream in streamIdentifiers)
        {
          //Match match = Regex.Match(stream, @"^\-?\d{1,2}(\:[avstd]{1})*$");  //A stricter version
          Match match = Regex.Match(stream, @"^\-?\d{1,2}(\:[a-z]+)*$");  //A more relaxed version

          if (match.Success)
            ffmpegOptions += @" -map " + stream;
        }

      }
      else
      //Simple Mapping Options
        if (!ConvConfig.includeVidStreams && !ConvConfig.includeAudStreams && !ConvConfig.includeSubStreams && !ConvConfig.includeAttStreams && !ConvConfig.includeDatStreams)
        {
          ffmpegOptions += @" -map -0";
        }
        else
        {
          ffmpegOptions += @" -map 0";

          if (!ConvConfig.includeVidStreams)
            ffmpegOptions += @" -map -0:v";
          if (!ConvConfig.includeAudStreams)
          {
            ffmpegOptions += @" -map -0:a";
          }
          else
          if (ConvConfig.audlangswitch && !String.IsNullOrWhiteSpace(ConvConfig.alanguage))
          {
              ffmpegOptions += @" -map 0:m:language:" + ConvConfig.alanguage;
          }
          if (!ConvConfig.includeSubStreams || ConvConfig.useSubFilter)
            ffmpegOptions += @" -map -0:s";
          if (!ConvConfig.includeAttStreams || ConvConfig.useSubFilter)
            ffmpegOptions += @" -map -0:t";
          if (!ConvConfig.includeDatStreams)
            ffmpegOptions += @" -map -0:d";
        }


      //Video Codec
      if (!String.IsNullOrWhiteSpace(ConvConfig.vcodec) && ConvConfig.vcodec != "Default")
        ffmpegOptions += @" -c:v " + ConvConfig.vcodec;

      //Video Options
      //X264 Options
      //Custom X264
      if (!String.IsNullOrWhiteSpace(ConvConfig.customx264arg))
      {
        ffmpegOptions += @" " + ConvConfig.customx264arg;
      }
      else
      {
        if (ConvConfig.vcodec == "libx264")
        {
          //X264 Presets
          if (!String.IsNullOrWhiteSpace(ConvConfig.x264preset))
            ffmpegOptions += @" -preset " + ConvConfig.x264preset;

          //X264 Tune
          if (!String.IsNullOrWhiteSpace(ConvConfig.x264tune))
            ffmpegOptions += @" -tune " + ConvConfig.x264tune;

          //X264 Level
          if (!String.IsNullOrWhiteSpace(ConvConfig.x264level))
            ffmpegOptions += @" -level " + ConvConfig.x264level;
        }

        //X264 Profile
        if (ConvConfig.vcodec == "libx264" && !String.IsNullOrWhiteSpace(ConvConfig.x264profile))
          ffmpegOptions += @" -profile:v " + ConvConfig.x264profile;
        else if (!String.IsNullOrWhiteSpace(ConvConfig.vprofile))
          ffmpegOptions += @" -profile:v " + ConvConfig.vprofile;

        //X264 Pre-test
        if (ConvConfig.x264pretest)
        {
          if (ConvConfig.x264offsettime > 0)
            ffmpegOptions += @" -ss " + ConvConfig.x264offsettime;
          if (ConvConfig.x264outduration > 0)
            ffmpegOptions += @" -t " + ConvConfig.x264outduration;
        }

        //X264opts
        if (ConvConfig.usex264opts)
        {
          if (!String.IsNullOrWhiteSpace(ConvConfig.x264optsarg))
            ffmpegOptions += @" -x264opts """ + ConvConfig.x264optsarg + @"""";
        }
        else if (ConvConfig.usex264params)
        {
          if (!String.IsNullOrWhiteSpace(ConvConfig.x264optsarg))
            ffmpegOptions += @" -x264-params """ + ConvConfig.x264optsarg + @"""";
        }

        //X264FPS
        if (!String.IsNullOrWhiteSpace(ConvConfig.x264fps))
        {
          if (int.Parse(ConvConfig.x264fps) > 0)
            ffmpegOptions += @" -fps " + ConvConfig.x264fps;
        }
      }

      //Video Scaling Algorithm
      if (!String.IsNullOrWhiteSpace(ConvConfig.vscaler))
        ffmpegOptions += @" -sws_flags " + ConvConfig.vscaler;

      //Video Resize
      if (ConvConfig.vresize && ConvConfig.vheight > 1 && (ConvConfig.vwidth == -2 || ConvConfig.vwidth > 1))
        vfilters.Add("scale=" + ConvConfig.vwidth + ":" + ConvConfig.vheight);

      //Video Quality
      if (ConvConfig.vcodec == "libx264" && ConvConfig.x264crf > 0)
      {
        ffmpegOptions += @" -crf " + ConvConfig.x264crf.ToString();
      }
      else if (ConvConfig.videobitkb > 0)
      {
        ffmpegOptions += @" -b:v " + ConvConfig.videobitkb.ToString() + "k";
      }

      //Audio Codec
      if (!String.IsNullOrWhiteSpace(ConvConfig.acodec) && ConvConfig.acodec != "Default")
        ffmpegOptions += @" -c:a " + ConvConfig.acodec;

      //Audio Options
      if (ConvConfig.audioexperimental)
        ffmpegOptions += @" -strict experimental";

      //Audio Quality
      if (ConvConfig.audiobitkb > 0)
        ffmpegOptions += @" -b:a " + ConvConfig.audiobitkb.ToString() + "k";

      if (ConvConfig.audiochannel > 0)
        ffmpegOptions += @" -ac " + ConvConfig.audiochannel;

      if (!String.IsNullOrWhiteSpace(ConvConfig.ahrate) && int.Parse(ConvConfig.ahrate) > 0 && ConvConfig.ahrate.Length == 5)
        ffmpegOptions += @" -ar " + ConvConfig.ahrate;

      //Misc. Options
      if (!String.IsNullOrWhiteSpace(ConvConfig.rframerate) && int.Parse(ConvConfig.rframerate) > 0 )
        ffmpegOptions += @" -r " + ConvConfig.rframerate;
    }

    /// <summary>
    /// Placeholder. Starts process associated with Convert Class.
    /// </summary>
    /// <param name="argument">The program arguments.</param>
    /// <param name="workingDirectory">The working directory for the program.</param>
    public static void StartProcess(string arguments, string workingDirectory)
    {
    //Main process
      ProcessStartInfo convertProcess = new ProcessStartInfo();

      convertProcess.FileName = Program.ffmpegExe;
      convertProcess.Arguments = arguments;

      convertProcess.UseShellExecute = false;
      convertProcess.CreateNoWindow = false;
      convertProcess.WorkingDirectory = workingDirectory;
      convertProcess.WindowStyle = ProcessWindowStyle.Hidden;
      convertProcess.RedirectStandardInput = true;

      using (Process process = Process.Start(convertProcess))
      {
        process.WaitForExit();
      }

    }
  }
}
