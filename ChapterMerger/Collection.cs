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
  //SuidLister Object: object that stores suid information of every file object it receives
  class SuidLister
  {
    public List<Suid> suidList = new List<Suid>();

    public SuidLister()
    {

    }

    public SuidLister(FileObject file)
    {
      var suidobj = new Suid();

      suidobj.fileName = file.filename;
      suidobj.suid = file.suid;

      suidList.Add(suidobj);
    }

    public void addSuid(FileObject file)
    {
      var suidobj = new Suid();

      suidobj.fileName = file.filename;
      suidobj.fullPath = file.fullpath;
      suidobj.suid = file.suid;

      //Console.WriteLine("New SUID Object suid: " + file.suid);

      suidList.Add(suidobj);
    }

  }

  //FileObjectCollection Object: contains list of FileObject; useful for operations that require a full list of files passed to this program
  public class FileObjectCollection
  {
    public List<FileObject> fileList = new List<FileObject>();
    public string folderPath { get; set; }
    public string name { get; set; }
    public bool hasOrdered { get; set; }

    public void addFile(FileObject file)
    {
      fileList.Add(file);
    }

  }

}
