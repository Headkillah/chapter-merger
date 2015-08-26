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

namespace ChapterMerger
{
  //File Object Class: represents the file(s) passed as argument to this program
  //Most fields and methods are self-explanatory
  public class FileObject
  {

    public string extension;
    public string filename;
    public string fullpath;
    public string filenameNoExtension;
    public string fullpathNoExtension;
    public string root;
    public string directoryname;
    public string suid;
    public string mkvInfo;
    public string ffInfo;
    public int splitCount;
    public bool shouldJoin;

    public List<ChapterAtom> chapterAtom = new List<ChapterAtom>();
    public List<MergeArgument> mergeArgument = new List<MergeArgument>();
    public List<DelArgument> delArgument = new List<DelArgument>();
    public List<TimeCode> timeCode = new List<TimeCode>();
    //public List<MediaStream> mediaStream = new List<MediaStream>();

    public MediaInfo mediaInfo = new MediaInfo();

    public FileObject()
    {

    }

    public FileObject(string path)
    {

      this.extension = Path.GetExtension(path);
      this.filename = Path.GetFileName(path);
      this.filenameNoExtension = Path.GetFileNameWithoutExtension(path);
      this.directoryname = Path.GetDirectoryName(path);
      this.fullpathNoExtension = Path.Combine(this.directoryname, this.filenameNoExtension);
      this.root = Path.GetPathRoot(path);
      this.fullpath = Path.GetFullPath(path);

    }

    public void addMkvInfo(string mkvinfo)
    {
      this.mkvInfo = mkvinfo;
    }

    public void addFFInfo(string ffinfo)
    {
      this.ffInfo = ffinfo;
    }

    public void addChapter(int chapterNum, string timeStart, string timeEnd, string suid = null, string chapterInfo = null)
    {
      ChapterAtom chapter = new ChapterAtom();

      chapter.chapterNum = chapterNum;
      chapter.timeStart = timeStart;
      chapter.timeEnd = timeEnd;
      chapter.suid = suid;
      chapter.chapterInfo = chapterInfo;

      chapterAtom.Add(chapter);

    }

    public void addSuid(string suid)
    {
      this.suid = suid;
    }

    public void addMergeArg(string mergeargfull, int chapterNum, bool isExternalSuid, string timeCode = null, string mergearg = null, string originalarg = null)
    {
      MergeArgument mergeargument = new MergeArgument();

      mergeargument.fullPath = mergeargfull;
      mergeargument.fileName = mergearg;
      mergeargument.chapterNum = chapterNum;
      mergeargument.timeCode = timeCode;
      mergeargument.originalFullPath = originalarg;
      mergeargument.isExternalSuid = isExternalSuid;

      mergeArgument.Add(mergeargument);

    }

    public void addTimeCode(string timecode)
    {
      TimeCode timec = new TimeCode();
      timec.timeCode = timecode;

      timeCode.Add(timec);
    }

    public void addDelArg(string delargfull, string delarg = null)
    {
      DelArgument delargument = new DelArgument();
      delargument.fileName = delarg;
      delargument.fullPath = delargfull;

      delArgument.Add(delargument);
    }

  }
}
