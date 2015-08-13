# ChapterMerger
A .Net-based mkvmerge wrapper for merging ordered chapters (segment linked chapters), currently for Windows.

## What
ChapterMerger provides a simple, useful GUI for "unordering" of ordered MKV files, with a simple "project" management.

Ordered MKV files for this purpose are MKV files that has chapter tracks that uses a "segment link" to an external file.

Segment Linking is a feature of the MKV container that allows chapter tracks to abstractly represent external files as a part of the original stream container that houses the chapter tracks.
It is useful on multiple MKV files that contain the same repeating part. Great examples of this are TV series, notably Anime and most TV shows.
It can significantly reduce file sizes.

"Unordering", thus, is the attempt to merge the actual linked file by the chapter track to the main file itself.

Ordered chapters has its own benefit, but this "unordering" phenomenon is useful when you are trying to play these MKV files on players that doesn't support segment linking on MKV files, while consequently gaining a percentage increase in file sizes (and losing the chapters information, for now).

Although all descriptions above may be inaccurate. You can find more about them by searching through the vast space of the Internet.

Currently, this program only does the one simple task above.

## How
You need [MKVToolNix](https://www.bunkus.org/videotools/mkvtoolnix/) to even be able to launch this program. Download it and install/extract it anywhere you want. Then put this program's executable inside the MKVToolNix folder. Alternatively, you can run this program anywhere provided that the MKVToolNix folder is included in the PATH environment variable. 

You also need to have [.Net Framework 4.0](http://www.microsoft.com/en-us/download/details.aspx?id=17851) installed in your computer.

### How To Build
This project is developed using Microsoft Visual Studio 2013.

To build, open the respective *.csproj in this project folder in Visual Studio 2013. Press F5 or equivalently, choose "Build Solution" under "Build" menu.
The produced executable file is usually found under "bin\debug" or "bin\release".

## Why
ChapterMerger was conceived not because of lack of tools and techniques to do the same task (e.g. MKVToolNix GUI options), but because simply searching for the right segment linked file in many MKV files and manually merging them is a pain in the buttocks. This program attempts to simplify these tasks. Although, this program was also born as a pet project for C#.

## Mono implementation support
This program is not tested in [Mono](http://www.mono-project.com/). This program does not currently support Mono. Maybe, in the near future!

## Thanks
[MKVToolNix team](https://www.bunkus.org/videotools/mkvtoolnix/) for the great tool. The idea behind this program was conceived merely upon using mkvtoolnix tools.