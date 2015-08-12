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
  public static class ExtensionClass
  {
    public static int ToPercentage(this int value, int total)
    {
      int percent = (int)Math.Round((double)(100 * value) / total);

      return percent;
    }

    public static string Truncate(this string value, int maxLength)
    {
      if (string.IsNullOrEmpty(value)) return value;

      return value.Length <= maxLength ? value : value.Substring(0, maxLength) + " ..";
    }

    public static string TruncateMiddle(this string value, int maxLength)
    {
      if (string.IsNullOrEmpty(value)) return value;
      if (value.Length < maxLength + 2) return value;

      var tempValue = value.Substring(0, maxLength / 2) + " ..." + value.Substring(value.Length - (maxLength / 2));
      return tempValue;
    }

    public static string TruncateLeft(this string value, int maxLength)
    {
      if (string.IsNullOrEmpty(value)) return value;
      if (value.Length < maxLength + 2) return value;

      var tempValue = value.Substring(0, (int)(maxLength / 2.75)) + " ..." + value.Substring(value.Length - (int)(maxLength / 1.25));
      return tempValue;
    }

    public static string TruncateLast(this string value, int maxLength)
    {
      if (string.IsNullOrEmpty(value)) return value;
      if (value.Length < maxLength + 2) return value;

      var tempValue = "..." + value.Substring(value.Length - maxLength);
      return tempValue;
    }

  }
}
