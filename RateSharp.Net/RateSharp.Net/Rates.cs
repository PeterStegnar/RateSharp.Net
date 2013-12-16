//  ***********************************************************************
//   Solution	: RateSharp.Net
//   Project	: RateSharp.Net
//   Author		: F Aydin
//   Created	: 23:08, 15:12:2013
//    
//   Last Modified By	: F Aydin
//   Last Modified On 	: 00:53, 16:12:2013
//  ***********************************************************************

using Newtonsoft.Json;

using RateSharp.Net.Converter;
using RateSharp.Net.Enums;
using RateSharp.Net.Models;
using RateSharp.Net.Util;

namespace RateSharp.Net
{
    public class Rates
    {
        /// <summary>
        ///     Retrieves the bar data on a specified time period and symbol
        /// </summary>
        /// <param name="timePeriod">The time period</param>
        /// <param name="symbol">The symbol</param>
        /// <returns>Most recent bar data</returns>
        public Bar Get(TimePeriod timePeriod, Symbol symbol)
        {
            var url = string.Format("http://api.apirates.com/update/FREE/{0}/{1}", timePeriod, symbol);
            var json = Web.Get(url);
            return JsonConvert.DeserializeObject<Bar>(json, new DateTimeConverter());
        }

        /// <summary>
        ///     Retrieves the bar data on a all time periods for the specified symbol
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <returns>Most recent bar data on all time periods</returns>
        public Period GetAll(Symbol symbol)
        {
            var url = string.Format("http://api.apirates.com/update/FREE/ALL/{0}", symbol);
            var json = Web.Get(url);
            return JsonConvert.DeserializeObject<Period>(json, new DateTimeConverter());
        }
    }
}
