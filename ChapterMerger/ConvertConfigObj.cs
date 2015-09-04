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

namespace ChapterMerger
{
  /// <summary>
  /// Contains the configuration required for conversion process.
  /// </summary>
  public class ConvertConfigure
  {
    public bool shutdownDevice = false;
    public bool showCommands = false; //Added for diagnostics
    public bool showFFmpegWindow = true; //Added for diagnostics; better as true for now, as an interactive hidden FFmpeg thread is yet to be constructed.

    public string format = "mkv";

    public string vcodec = "libx264";
    public string acodec = "libmp3lame";
    public int? videobitkb = 1000;
    public int? audiobitkb = 192;

    public bool vresize = false;
    public bool maintainAspectRatio = true;
    public string vscaler = "lanczos";
    public int vheight = 720;
    public int vwidth = -2;
    public string vprofile = "";

    public int x264crf = 19;
    public string x264preset = "veryfast";
    public string x264tune = "";
    public bool x264hi10 = false;
    public string x264profile = "";
    public string x264level = "";
    public bool x264faststart = false;
    public bool x264pretest = false;
    public int x264offsettime = 0;
    public int x264outduration = 0;
    public string x264fps = ""; //Used string instead of decimal, since it will be parsed and passed as a string anyway
    public bool usex264opts = false;
    public bool usex264params = false;  //Added as an alternative to x264opts
    public string x264optsarg = "";
    public string customx264arg = ""; //Deprecated, as this can be supplemented by customffmpegarg.

    public bool audioexperimental = false;
    public int audiochannel = 2;
    public string ahrate = "";  //Used string instead of int, as its default value is empty/null (Could use a nullable type, but ain't nobody got time for that)
    public bool audlangswitch = false;
    public string alanguage = "";
    
    public bool useVFilter = false;
    public bool fixsubduration = false;
    public bool externalsubs = false;
    public string externalsubsext = "ass";
    public bool useSubFilter = false;
    public int subindex = 0;

    public bool includeVidStreams = true;
    public bool includeAudStreams = true;
    public bool includeSubStreams = true;
    public bool includeAttStreams = true;
    public bool includeDatStreams = true; //For metadata, etc.

    public string customvfilter = "";
    public string custommapping = "";
    public string customffmpegarg = "";

    public int fps = 0;
    public string rframerate = ""; //Used string instead of int, since it will be parsed and passed as a string anyway

    public string newfileprefix = "";
    public string newfilesuffix = "(Converted)";

  }

  /*
   * Enums
   * 
   * */
  public enum X264Presets
  {
    ultrafast,
    superfast,
    veryfast,
    faster,
    fast,
    medium, //Changed back to previous value; causes unexpected behaviour
    slow,
    slower,
    veryslow,
    placebo
  }

  public enum VideoCodecs
  {
    libx264,
    libx265,
    mpeg4,
    libxvid,
    flv,
    mpegvideo,
    mpeg2video
  }

  public enum AudioCodecs
  {
    libmp3lame,
    aac,
    libvo_aacenc,
    vorbis,
    libvorbis,
    libopus,
    mp2,
    mp2fixed,
    libtwolame,
    dca,
    ac3,
    ac3_fixed,
    flac
  }

  public enum VideoFormats
  {
    mkv,
    mp4,
    avi,
    wmv
  }

  public enum AudioFormats
  {
    mp3,
    m4a,
    flac,
    wav
  }

  public enum X264Tunes
  {
    film,
    animation,
    grain,
    stillimage,
    psnr,
    ssim,
    fastdecode,
    zerolatency
  }

  public enum SubtitleFormats
  {
    ass,
    srt,
    ssa,
    sub
  }

  public enum X264Profiles
  {
    baseline,
    main,
    high,
    high10,
    high422,
    high444
  }

  public enum LanguageCodes
  {
    ara,
    bul,
    chi,
    cze,
    dan,
    dut,
    egy,
    eng,
    fin,
    fre,
    ger,
    gre,
    heb,
    hun,
    ind,
    ita,
    jpn,
    kor,
    nor,
    pol,
    por,
    rum,
    rus,
    spa,
    tag,
    tha,
    tur,
    ukr,
    vie
  }

  public enum VideoScalerAlgorithms
  {
    fast_bilinear,
    bilinear,
    bicubic,
    experimental,
    neighbor,
    area,
    bicublin,
    gauss,
    sinc,
    lanczos,
    spline
  }
  /*
   * End of Enums
   * 
   * */

}
