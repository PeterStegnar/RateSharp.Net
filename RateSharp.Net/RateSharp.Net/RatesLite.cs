//  ***********************************************************************
//   Solution	: RateSharp.Net
//   Project	: RateSharp.Net
//   Author		: F Aydin
//   Created	: 01:34, 16:12:2013
//    
//   Last Modified By	: F Aydin
//   Last Modified On 	: 12:42, 16:12:2013
//  ***********************************************************************

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using RateSharp.Net.Converter;
using RateSharp.Net.Enums;
using RateSharp.Net.Models;
using RateSharp.Net.Util;

namespace RateSharp.Net
{
    /// <summary>
    ///     <para>The free version of APIRates.com.</para>
    ///     <para>Pricing data provided in the API instance are valid real-time data from markets,</para>
    ///     <para>but meant for testing purposes only.</para>
    ///     <para>Only the EURUSD symbol is available in this Lite version.</para>
    /// </summary>
    public class RatesLite
    {
        /// <summary>
        ///     Retrieves the pricing data on a specified time period for the EURUSD symbol
        /// </summary>
        /// <param name="timePeriod">The time period</param>
        /// <returns>Most recent pricing data</returns>
        public static SymbolBar GetBarUpdate(TimePeriod timePeriod)
        {
            var url = string.Format("http://api.apirates.com/update/FREE/{0}/EURUSD", timePeriod);
            var json = Web.Get(url);
            return JsonConvert.DeserializeObject<SymbolBar>(json, new DateTimeConverter());
        }

        /// <summary>
        ///     Retrieves the pricing data on all time periods for the EURUSD symbol
        /// </summary>
        /// <returns>Most recent bar data on all time periods</returns>
        public static Period GetAllPeriodsUpdate()
        {
            var url = string.Format("http://api.apirates.com/update/FREE/ALL/EURUSD");
            var json = Web.Get(url);
            return JsonConvert.DeserializeObject<Period>(json, new DateTimeConverter());
        }

        /// <summary>
        ///     Retrieves the pricing history for the EURUSD symbol.
        /// </summary>
        /// <param name="timePeriod">The time period</param>
        /// <param name="fromDateTime">The date you wish to retrieve the history since</param>
        /// <returns>A list containing every pricing data dating back to the specified from date</returns>
        public static List<SymbolBar> GetBarHistory(TimePeriod timePeriod, DateTime fromDateTime)
        {
            var url = string.Format("http://api.apirates.com/history/FREE/{0}/EURUSD/{1}", timePeriod, fromDateTime.ToEpochTime());
            var json = Web.Get(url);
            return JsonConvert.DeserializeObject<List<SymbolBar>>(json, new DateTimeConverter());
        }
    }
}
