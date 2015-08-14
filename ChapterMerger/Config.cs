﻿/*
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
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace ChapterMerger
{
  public static class Config
  {
    public static Configure Configure;

    public static string configPath = Program.defaultPath;
    public static string configFile = Path.Combine(configPath, "config.xml");

    public static void Initialize()
    {
      Configure = new Configure();
    }

    public static void writeConfiguration()
    {
      XmlSerializer xmlWrite = new XmlSerializer(typeof(Configure));

      FileStream xmlfile = File.Create(configFile);

      xmlWrite.Serialize(xmlfile, Config.Configure);

      xmlfile.Close();

      XmlDocument xmldoc = new XmlDocument();

      xmldoc.Load(configFile);

      XmlComment newComment;
      newComment = xmldoc.CreateComment("ChapterMerger Configuration File. DO NOT EDIT THIS FILE UNLESS YOU KNOW WHAT YOU'RE DOING.");

      XmlElement root = xmldoc.DocumentElement;
      xmldoc.InsertBefore(newComment, root);

      xmldoc.Save(configFile);

    }

    public static void getConfiguration()
    {

      if (File.Exists(configFile))
      {
        XmlSerializer xmlRead = new XmlSerializer(typeof(Configure));

        using (FileStream fileStream = new FileStream(configFile, FileMode.Open))
        {
          Configure = (Configure)xmlRead.Deserialize(fileStream);
        }
      }
      else
      {
        Initialize();
        writeConfiguration();
      }

    }
  }
}

