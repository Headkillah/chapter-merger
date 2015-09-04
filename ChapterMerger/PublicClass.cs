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

namespace ChapterMerger
{
  /// <summary>
  /// Represents SUID information format for SuidLister usage
  /// </summary>
  public class Suid
  {
    public string fileName { get; set; }
    public string fullPath { get; set; }
    public string suid { get; set; }
  }

  /// <summary>
  /// Represents individual chapters for every File Object
  /// </summary>
  public class ChapterAtom
  {
    public string chapterInfo { get; set; }
    public int chapterNum { get; set; }
    public string timeStart { get; set; }
    public string timeEnd { get; set; }
    public string suid { get; set; }
    public string suidFileName { get; set; }
    public string suidFullPath { get; set; }

    /// <summary>
    /// Add a file that represents this chapter's externally linked SUID.
    /// </summary>
    /// <param name="file">The representing FileObject.</param>
    public void addSuidFileName(FileObject file)
    {
      this.suidFileName = file.filename;
      this.suidFullPath = file.fullpath;
    }
  }

  /// <summary>
  /// Holds information on what and how the files will be merged.
  /// </summary>
  public class MergeArgument
  {
    public string timeCode { get; set; }
    public string fileName { get; set; }
    public string fullPath { get; set; }
    public string originalFullPath { get; set; }
    public int chapterNum { get; set; }
    public bool isExternalSuid { get; set; }

  }

  /// <summary>
  /// Holds the list of files to be deleted.
  /// </summary>
  public class DelArgument
  {
    public string fileName { get; set; }
    public string fullPath { get; set; }
  }

  /// <summary>
  /// Holds the entire timecodes for splitting.
  /// </summary>
  public class TimeCode
  {
    public string timeCode { get; set; }
  }

  /// <summary>
  /// Holds mutable progress data.
  /// </summary>
  public class ProgressState
  {
    public string fileName { get; set; }
    public string listName { get; set; }
    public string progressDetail { get; set; }
    public int progressPercent { get; set; }
    public int progressArg { get; set; }
    public Object data { get; set; }  //For misc. progress data. Maybe seldom used.
  }

  /// <summary>
  /// Holds the file's general media information.
  /// </summary>
  public class MediaInfo
  {
    public string inputInfo { get; set; }
    public string duration { get; set; }
    public int bitratekb { get; set; }
    public List<MediaStream> mediaStreams { get; set; }

  }

  /// <summary>
  /// Holds information of individual media streams inside the container.
  /// </summary>
  public class MediaStream
  {
    public MediaType mediaType { get; set; }
    public string codec { get; set; }
    public string codecInfo { get; set; }
    public string metaData { get; set; }

  }

  /// <summary>
  /// A list of media types.
  /// </summary>
  public enum MediaType
  {
    None,
    Video,
    Audio,
    Image,
    Subtitle,
    Attachment
  }

  /// <summary>
  /// Models data involved with various tasks like file handling, conversion, and merging.
  /// </summary>
  public static class MediaData
  {
    //Temporary list of extensions; maybe replaced by a more proper global list in the future.

    /// <summary>
    /// Holds a list of known file types/extensions.
    /// </summary>
    public static string[] extensions = {
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


  }
}
