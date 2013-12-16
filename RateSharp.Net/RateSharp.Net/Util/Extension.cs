//  ***********************************************************************
//   Solution	: RateSharp.Net
//   Project	: RateSharp.Net
//   Author		: F Aydin
//   Created	: 11:23, 16:12:2013
//    
//   Last Modified By	: F Aydin
//   Last Modified On 	: 11:26, 16:12:2013
//  ***********************************************************************

using System;

namespace RateSharp.Net.Util
{
    internal static class Extension
    {
        public static DateTime FromEpochTime(this long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public static long ToEpochTime(this DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date - epoch).TotalSeconds);
        }

        public static string FixIfEmpty(this string api)
        {
            return string.IsNullOrWhiteSpace(api) ? "0" : api;
        }
    }
}
