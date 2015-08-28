using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChapterMerger
{
  /// <summary>
  /// Place Holder ConvertConfigure, for now
  /// </summary>
  public class ConvertConfigure
  {
    public bool shutdownDevice = false;

    public string format = "mkv";

    public string vcodec = "libx264";
    public string acodec = "libmp3lame";
    public int? videobitkb = 500;
    public int? audiobitkb = 128;

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
    public string x264optsarg = "";
    public string customx264arg = "";

    public bool audioexperimental = false;
    public int audiochannel = 0;
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

    //public string[] vfilters = { "" }; //Temporary placeholders for vfilters; yet for use
    //public string[] mapping = { "0" };

    public string customvfilter = "";
    public string custommapping = "";
    public string customffmpegarg = "";

    public int fps = 0;
    public int rframerate = 0;

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
    medium = 0,
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
