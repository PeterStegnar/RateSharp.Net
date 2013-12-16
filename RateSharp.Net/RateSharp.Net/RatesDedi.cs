//  ***********************************************************************
//   Solution	: RateSharp.Net
//   Project	: RateSharp.Net
//   Author		: F Aydin
//   Created	: 09:38, 16:12:2013
//    
//   Last Modified By	: F Aydin
//   Last Modified On 	: 12:43, 16:12:2013
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
    ///     <para>The dedicated version of APIRates.com</para>
    ///     <para>Pricing data provided in the API instance are valid real-time data from markets,</para>
    ///     <para>but meant for testing purposes only.</para>
    /// </summary>
    public class RatesDedi
    {
        /// <summary>
        ///     Retrieves the pricing data on a specified time period for the specified symbol
        /// </summary>
        /// <param name="apiKey">Your API key.</param>
        /// <param name="timePeriod">The time period</param>
        /// <param name="symbol">The symbol</param>
        /// <returns>Most recent pricing data</returns>
        public static SymbolBar GetBarUpdate(string apiKey, TimePeriod timePeriod, Symbol symbol)
        {
            var url = string.Format("http://api.apirates.com/update/{0}/{1}/{2}", apiKey.FixIfEmpty(), timePeriod, symbol);
            var json = Web.Get(url);
            return JsonConvert.DeserializeObject<SymbolBar>(json, new DateTimeConverter());
        }

        /// <summary>
        ///     Retrieves the pricing data for every symbol.
        /// </summary>
        /// <param name="apiKey">Your API key.</param>
        /// <param name="timePeriod">The time period</param>
        /// <returns>Most recent pricing data for every symbol</returns>
        public static SymbolLot GetLotUpdate(string apiKey, TimePeriod timePeriod)
        {
            var url = string.Format("http://api.apirates.com/update/{0}/{1}", apiKey.FixIfEmpty(), timePeriod);
            var json = Web.Get(url);
            return JsonConvert.DeserializeObject<SymbolLot>(json, new DateTimeConverter());
        }

        /// <summary>
        ///     Retrieves the specified symbols history.
        /// </summary>
        /// <param name="apiKey">You API key</param>
        /// <param name="timePeriod">The time period</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="fromDateTime">The date and time the pricing data should reach back to</param>
        /// <returns>A list containing every pricing data dating back to the specified from date</returns>
        public static List<SymbolBar> GetBarHistory(string apiKey, TimePeriod timePeriod, Symbol symbol, DateTime fromDateTime)
        {
            
            var url = string.Format("http://api.apirates.com/history/{0}/{1}/{2}/{3}", apiKey.FixIfEmpty(), timePeriod, symbol, fromDateTime.ToEpochTime());
            var json = Web.Get(url);
            return JsonConvert.DeserializeObject<List<SymbolBar>>(json, new DateTimeConverter());
        }

        /// <summary>
        ///     Retrieves the pricing data on all time periods for the specified symbol.
        /// </summary>
        /// <returns>Most recent pricing data on all time periods</returns>
        public static Period GetAllPeriodsUpdate(string apiKey, Symbol symbol)
        {
            var url = string.Format("http://api.apirates.com/update/{0}/ALL/{1}", apiKey.FixIfEmpty(), symbol);
            var json = Web.Get(url);
            return JsonConvert.DeserializeObject<Period>(json, new DateTimeConverter());
        }
    }
}
