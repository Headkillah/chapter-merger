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
  public class Configure
  {
    public int diagnose = 0;

    public bool launchGui = true;
    //public bool doAnalyze = false;
    public bool doMakeXml = false;
    public bool doMakeScript = false;

    public int exportlimit = 0;
    public int splittimecode = 1;
    public int universalsplit = 1;
    public bool includeMkvInfoOnFiles = false;
    public bool includeChapterInfoOnFiles = false;

    public bool sourceOutputFolder = true;
    public bool alwaysExecuteScript = false;
    public bool alwaysMerge = false;
    public bool noChapterOutput = true;
    public bool executeScriptAfter = false;
    public bool projectIncludeFileList = false;

    public string exportfilename = "";
    public string tempfileprefix = "";
    public string tempfilesuffix = "_temp";
    public string newfileprefix = "";
    public string newfilesuffix = "(Merged)";

    public bool splitModeTimeEnd = true;
    public bool splitModeTimeStart = false;

    public string outputPath = "";

    //public string mkvInfoExePath = "";
    //public string mkvMergeExePath = "";

    public bool diagnoseMkvinfoDump = false;
    public bool diagnoseChapterinfoDump = false;

  }
}
