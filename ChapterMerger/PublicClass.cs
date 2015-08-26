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
  //Public Object Suid: represents SUID information format for SuidLister usage
  public class Suid
  {
    public string fileName { get; set; }
    public string fullPath { get; set; }
    public string suid { get; set; }
  }

  //Public Object ChapterAtom: represents individual chapters for every File Object
  public class ChapterAtom
  {
    public string chapterInfo { get; set; }
    public int chapterNum { get; set; }
    public string timeStart { get; set; }
    public string timeEnd { get; set; }
    public string suid { get; set; }
    public string suidFileName { get; set; }
    public string suidFullPath { get; set; }

    public void addSuidFileName(FileObject file)
    {
      this.suidFileName = file.filename;
      this.suidFullPath = file.fullpath;
    }
  }

  //Public Objects MergeArgument, DelArgument, TimeCode: each holds respective information for every File Object
  public class MergeArgument
  {
    public string timeCode { get; set; }
    public string fileName { get; set; }
    public string fullPath { get; set; }
    public string originalFullPath { get; set; }
    public int chapterNum { get; set; }
    public bool isExternalSuid { get; set; }

  }

  public class DelArgument
  {
    public string fileName { get; set; }
    public string fullPath { get; set; }
  }

  public class TimeCode
  {
    public string timeCode { get; set; }
  }

  public class ProgressState
  {
    public string fileName { get; set; }
    public string listName { get; set; }
    public string progressDetail { get; set; }
    public int progressPercent { get; set; }
    public int progressArg { get; set; }
  }

  public class MediaInfo
  {
    public string inputInfo { get; set; }
    //public string vcodec { get; set; }  //removed; MediaStream already includes this
    //public string acodec { get; set; }  //removed; MediaStream already includes this
    public string duration { get; set; }
    //public int vheight { get; set; }    //removed; MediaStream already includes this
    //public int vwidth { get; set; }     //removed; MediaStream already includes this
    //public int videobitkb { get; set; } //removed; input info doesn't provide this data
    //public int audiobitkb { get; set; } //removed; input info doesn't provide this data
    public int bitratekb { get; set; }
    public List<MediaStream> mediaStreams { get; set; }

  }

  public class MediaStream
  {
    public MediaType mediaType { get; set; }
    public string codec { get; set; }
    public string codecInfo { get; set; }
    public string metaData { get; set; }

  }

  public enum MediaType
  {
    None,
    Video,
    Audio,
    Image,
    Subtitle,
    Attachment
  }
}
