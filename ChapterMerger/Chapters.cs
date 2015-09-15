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
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Diagnostics;
using System.IO;

namespace ChapterMerger
{
  /// <summary>
  /// This class attempts to mimic the Chapter file XML data structure, using the specification found at http://matroska.org/technical/specs/chapters/index.html.
  /// Some data types are not followed purely for convenience. This class as a representation may be incomplete.
  /// </summary>
  [XmlRoot("Chapters")]
  public class ChaptersObject
  {

    [XmlElement("EditionEntry")]
    public EditionEntryClass EditionEntry = new EditionEntryClass();

    /// <summary>
    /// EditionEntry Master Element. This is the general chapter file data.
    /// </summary>
    public class EditionEntryClass
    {
      public int EditionFlagDefault { get; set; }
      public int EditionFlagOrdered { get; set; }
      public string EditionUID { get; set; }  //Changed to string, as it is parsed as a sting
      public int EditionFlagHidden { get; set; }

      [XmlElement("ChapterAtom")]
      public List<ChapterAtomClass> ChapterAtoms = new List<ChapterAtomClass>();

      /// <summary>
      /// ChapterAtom Master Element. This represents individual chapters
      /// </summary>
      public class ChapterAtomClass
      {
        public string ChapterTimeStart { get; set; }
        public string ChapterTimeEnd { get; set; }
        public string ChapterUID { get; set; }
        public string ChapterStringUID { get; set; }
        public ChapterSegmentUIDClass ChapterSegmentUID { get; set; }
        public string ChapterSegmentEditionUID { get; set; }  //Changed to string, as it is parsed as a sting
        public int ChapterFlagHidden { get; set; }
        public int ChapterFlagEnabled { get; set; }

        [XmlElement("ChapterDisplay")]
        public List<ChapterDisplayClass> ChapterDisplay = new List<ChapterDisplayClass>();

        [XmlElement("ChapterTrack")]
        public List<ChapterTrackClass> ChapterTrack = new List<ChapterTrackClass>();

        [XmlElement("ChapterProcess")]
        public List<ChapterProcessClass> ChapterProcess = new List<ChapterProcessClass>();

        /// <summary>
        /// ChapterSegmentUID Element.
        /// </summary>
        public class ChapterSegmentUIDClass
        {
          [XmlAttribute("format")]
          public string Format = "hex";
          [XmlText]
          public string ChapterSegmentUID { get; set; }
        }

        /// <summary>
        /// ChapterDisplay Master Element. This includes display data for a chapter
        /// </summary>
        public class ChapterDisplayClass
        {
          public string ChapterString { get; set; }
          public string ChapterLanguage { get; set; }
          public string ChapterCountry { get; set; }
        }

        /// <summary>
        /// ChapterTrack Master Element. This includes track data for a chapter
        /// </summary>
        public class ChapterTrackClass
        {
          public string ChapterTrackNumber { get; set; }
        }

        /// <summary>
        /// ChapterProcess Master Element. This includes process data for a chapter
        /// </summary>
        public class ChapterProcessClass
        {
          public int ChapProcessCodecID { get; set; }
          public string ChapProcessPrivate { get; set; }

          [XmlElement("ChapterProcessCommand")]
          public List<ChapterProcessCommandClass> ChapterProcessCommand = new List<ChapterProcessCommandClass>();

          /// <summary>
          /// ChapterProcessCommand Master Element. Holds options for a process data for a chapter
          /// </summary>
          public class ChapterProcessCommandClass
          {
            public int ChapProcessTime { get; set; }
            public string ChapProcessData { get; set; }
          }
        }
      }
    }

    /// <summary>
    /// Returns a string representation of the Chapter File.
    /// </summary>
    /// <returns>The chapter file interpreted in string format.</returns>
    public string InterpretChapterFile()
    {

      XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
      {
        Indent = true,
        OmitXmlDeclaration = false,
        Encoding = Encoding.UTF8
      };

      var nameSpace = new XmlSerializerNamespaces();
      nameSpace.Add(string.Empty, string.Empty);

      using (MemoryStream memoryStream = new MemoryStream())
      using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings))
      {
        var x = new System.Xml.Serialization.XmlSerializer(this.GetType());
        x.Serialize(xmlWriter, this, nameSpace);
        
        memoryStream.Position = 0; // Rewind the stream for reading
        StreamReader sr = new StreamReader(memoryStream);
        return sr.ReadToEnd();
      }

    }

    /// <summary>
    /// Deserializes an existing chapter file and returns it as a new Chapters instance.
    /// </summary>
    /// <param name="chapterFile">The full path of the chapter file to process.</param>
    /// <returns>A shining, brand new Chapters instance.</returns>
    public static ChaptersObject LoadChapterFile(string chapterFile)
    {
      XmlSerializer xmlRead = new XmlSerializer(typeof(ChaptersObject));

      var chapters = new ChaptersObject();

      using (FileStream fileStream = new FileStream(chapterFile, FileMode.Open))
      {
        chapters = (ChaptersObject)xmlRead.Deserialize(fileStream);
      }

      return chapters;
    }

    /// <summary>
    /// Serializes this Chapters instance and saves it as a chapterFile.
    /// </summary>
    /// <param name="chapterFile">The full path of the chapter file to save.</param>
    public void SaveChapterFile(string chapterFile)
    {

      //Use an XDocument for further modifications
      XDocument xdoc = new XDocument();

      XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
      {
        Indent = true,
        OmitXmlDeclaration = false,
        Encoding = Encoding.UTF8
      };

      var nameSpace = new XmlSerializerNamespaces();
      nameSpace.Add(string.Empty, string.Empty);

      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings))
        {
          var x = new XmlSerializer(this.GetType());

          //Serialize this Chapters instance with provided XmlWriterSettings
          x.Serialize(xmlWriter, this, nameSpace);

          memoryStream.Position = 0; //Rewind the stream for reading
          StreamReader sr = new StreamReader(memoryStream);
        }

        //Read to XDocument from memoryStream
        xdoc = XDocument.Load(memoryStream);
      }

      List<object> comments = new List<Object> {
        new XComment("Created using ChapterMerger."),
        new XComment("DO NOT EDIT THIS FILE UNLESS YOU KNOW WHAT YOU'RE DOING.")
      };
     
      xdoc.Element("Chapters").AddBeforeSelf(comments);

      //Save the XML file.
      xdoc.Save(chapterFile);

    }
  }
}
