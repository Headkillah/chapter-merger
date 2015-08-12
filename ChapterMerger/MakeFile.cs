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
using System.IO;
using System.Xml.Serialization;

namespace ChapterMerger
{
  class MakeFile
  {

    //private int progress = 1;
    //private int processPercent = 0;

    public static string outputPath = Program.thisProgramPath;
    public static string dumpPath = Program.thisProgramPath + "\\dump";
    private static bool doMakeFile = false;

  /// <summary>
  /// Deprecated - Creates a script that executes mkvmerge commands to merge analyzed files
  /// </summary>
  /// <param name="fileList">The processed FileObjectCollection.</param>
  /// <param name="processor">The Analyze object</param>
  /// <param name="outputPathArg">Optional. Pass a different output path for the script.</param>
    public void makeFile(FileObjectCollection fileList, Analyze processor, string outputPathArg = null)
    {

      if (outputPathArg != null)
      {
        outputPath = outputPathArg;
      }
      else
        if (Config.Configure.sourceOutputFolder)
          outputPath = Path.Combine(fileList.folderPath, Config.Configure.exportfilename);
        else
          outputPath = Path.Combine(outputPath, Config.Configure.exportfilename);
      
        
      StringBuilder makeFileContent = new StringBuilder();

      if (Config.Configure.diagnoseMkvinfoDump | Config.Configure.diagnoseChapterinfoDump)
        Directory.CreateDirectory(dumpPath);

      foreach (FileObject file in fileList.fileList)
      {

        List<string> timeCodeList = new List<string>();
        List<string> delArgumentList = new List<string>();
        List<string> mergeArgumentList = new List<string>();
        List<string> chapterInfo = new List<string>();

        /*
         * Diagnostic purposes only
         * */
        if (Config.Configure.diagnoseMkvinfoDump)
          using (StreamWriter writer = new StreamWriter(Path.Combine(dumpPath, file.filenameNoExtension + "_mkvinfo.txt")))
          {
            writer.Write(file.mkvInfo);
          }

        /*
         * Main process
         * */
        if (file.mergeArgument.Count > 1)
        {

          foreach (MergeArgument merge in file.mergeArgument)
          {

            if (merge.isExternalSuid)
              mergeArgumentList.Add("\"" + merge.fullPath + "\"");
            else
            {
              if (file.splitCount > 1)
                mergeArgumentList.Add("\"" + merge.fileName + "\"");
              else
                mergeArgumentList.Add("\"" + merge.originalFullPath + "\"");

            }
               
          }

          foreach (TimeCode time in file.timeCode)
          {
            timeCodeList.Add(time.timeCode);
          }

          foreach (DelArgument del in file.delArgument)
          {
            delArgumentList.Add("\"" + del.fileName + "\"");
          }

          foreach (ChapterAtom chapter in file.chapterAtom)
          {
            chapterInfo.Add(chapter.chapterInfo);
          }

          string[] timeCode = timeCodeList.ToArray();
          string[] delArgument = delArgumentList.ToArray();
          string[] mergeArgument = mergeArgumentList.ToArray();
          string[] chaptersInfo = chapterInfo.ToArray();

          string tempFileName = "\"" + Config.Configure.tempfileprefix + file.filenameNoExtension + Config.Configure.tempfilesuffix + ".mkv\"";
          string newFileName = "\"output\\" + Config.Configure.newfileprefix + file.filenameNoExtension + Config.Configure.newfilesuffix + ".mkv\"";
          string originalFileName = "\"" + file.fullpath + "\"";

          if (file.shouldJoin)
          {

            doMakeFile = true;
            makeFileContent.AppendLine("::" + file.filename);

            if (file.splitCount > 1)
            {
              makeFileContent.AppendLine("mkvmerge --no-chapters --split timecodes:" + String.Join(",", timeCode) + " -o " + tempFileName + " " + originalFileName);
            }

            makeFileContent.AppendLine("mkvmerge --no-chapters -o " + newFileName + " " + String.Join(" +", mergeArgument) + "\r\n");
            makeFileContent.AppendLine("DEL /Q " + String.Join(" ", delArgument) + "\r\n");

          }

          if (Config.Configure.diagnoseChapterinfoDump)
            using (StreamWriter writer = new StreamWriter(Path.Combine(dumpPath, file.filenameNoExtension + "_chaptersinfo.txt")))
            {
              writer.WriteLine(String.Join("\n", chaptersInfo));
            }
        
        }


      }

      if (doMakeFile)
      {
        using (StreamWriter writer = new StreamWriter(outputPath))
        {
          writer.WriteLine("@echo off\r\ncls\r\n\r\npushd \"%~dp0\"\r\nif not exist output mkdir output\r\n");
          writer.Write(makeFileContent);
        }
        processor.orderedGroups.Add(outputPath);
      }
      else
      {

      }

    }

  /// <summary>
  /// Deprecated. There is no use for an xml file that holds fileList information.
  /// </summary>
  /// <param name="fileList">The FileObjectCollection to serialize into XML.</param>
  /// <param name="processor">The Processor object to get the file objects from.</param>
    public void makeXML(FileObjectCollection fileList, Analyze processor)
    {
      XmlSerializer xmlWrite = new XmlSerializer(typeof(FileObjectCollection));

      string fileListName = fileList.name + ".xml";

      FileStream xmlfile = File.Create(Path.Combine(outputPath, fileListName));

      xmlWrite.Serialize(xmlfile, fileList);

      xmlfile.Close();

    }

  }
}
