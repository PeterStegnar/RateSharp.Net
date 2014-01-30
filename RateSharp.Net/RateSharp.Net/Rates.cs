using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

using RateSharp.Net.Models.Converter;
using RateSharp.Net.Models.Enum;
using RateSharp.Net.Models;
using Utilities.Extension;
using Utilities.Web;

namespace RateSharp.Net
{
    public class Rates
    {
        public Rates(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey)) throw new Exception("The Api Key you have entered is invalid");
            _apiKey = apiKey;
        }

        private readonly string _apiKey;

        /// <summary>
        ///     Retrieves the pricing data on a specified time period for the specified symbol
        /// </summary>
        /// <returns>Most recent pricing data</returns>
        public SymbolBar GetBarUpdate(TimePeriod timePeriod, Symbol symbol)
        {
            var url = string.Format("http://api.apirates.com/update/{0}/{1}/{2}", _apiKey, timePeriod, symbol);
            var json = Http.Get(url);
            return JsonConvert.DeserializeObject<SymbolBar>(json, new DateTimeConverter());
        }

        /// <summary>
        ///     Retrieves the pricing data for every symbol.
        /// </summary>
        /// <param name="timePeriod">The time period</param>
        /// <returns>Most recent pricing data for every symbol</returns>
        public SymbolLot GetLotUpdate(TimePeriod timePeriod)
        {
            var url = string.Format("http://api.apirates.com/update/{0}/{1}", _apiKey, timePeriod);
            var json = Http.Get(url);
            var allSymbols = JsonConvert.DeserializeObject<SymbolLot>(json, new DateTimeConverter());
            
            var periodProperties = allSymbols.GetType().GetProperties();

            foreach (PropertyInfo property in periodProperties)
            {
                if (property.GetValue(allSymbols) is SymbolBar)
                {
                    var bar = (SymbolBar)property.GetValue(allSymbols);
                    bar.Timestamp = allSymbols.Timestamp;
                }

            }
            return allSymbols;
        }

        /// <summary>
        ///     Retrieves the specified symbols history.
        /// </summary>
        /// <param name="apiKey">You API key</param>
        /// <param name="timePeriod">The time period</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="fromDateTime">The date and time the pricing data should reach back to</param>
        /// <returns>A list containing every pricing data dating back to the specified from date</returns>
        public List<SymbolBar> GetBarHistory(TimePeriod timePeriod, Symbol symbol, DateTime fromDateTime)
        {
            var url = string.Format("http://api.apirates.com/history/{0}/{1}/{2}/{3}", _apiKey, timePeriod, symbol, fromDateTime.ToUtcEpoch());
            var json = Http.Get(url);
            List<SymbolBar> rt = JsonConvert.DeserializeObject<List<SymbolBar>>(json, new DateTimeConverter());
            Console.WriteLine(rt.Count);
            return rt;
            //return JsonConvert.DeserializeObject<List<SymbolBar>>(json, new DateTimeConverter());
        }

        /// <summary>
        ///     Retrieves the pricing data on all time periods for the specified symbol.
        /// </summary>
        /// <returns>Most recent pricing data on all time periods</returns>
        public Period GetAllPeriodsUpdate(Symbol symbol)
        {
            var url = string.Format("http://api.apirates.com/update/{0}/ALL/{1}", _apiKey, symbol);
            var json = Http.Get(url);
            return JsonConvert.DeserializeObject<Period>(json, new DateTimeConverter());
        }
    }
}
