using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RateSharp.Net.Models;
using RateSharp.Net.Models.Converter;
using RateSharp.Net.Models.Enum;
using Utilities.Extension;
using Utilities.Web;

namespace RateSharp.Net.Free
{
    public class Rates
    {
        /// <summary>
        ///     Retrieves the most recent bar for the EURUSD symbol.
        /// </summary>
        public SymbolBar GetBarUpdate(TimePeriod timePeriod)
        {
            string url = string.Format("http://api.apirates.com/update/FREE/{0}/EURUSD", timePeriod);
            string json = Http.Get(url);
            return JsonConvert.DeserializeObject<SymbolBar>(json, new DateTimeConverter());
        }

        /// <summary>
        ///     Retrieves the pricing data on all time periods for the EURUSD symbol
        /// </summary>
        public Period GetAllPeriodsUpdate()
        {
            string url = string.Format("http://api.apirates.com/update/FREE/ALL/EURUSD");
            string json = Http.Get(url);
            return JsonConvert.DeserializeObject<Period>(json, new DateTimeConverter());
        }

        /// <summary>
        ///     Retrieves the pricing history for the EURUSD symbol.
        /// </summary>
        /// <returns>A list containing every pricing data dating back to the specified time range</returns>
        public List<SymbolBar> GetBarHistory(TimePeriod timePeriod, DateTime fromDateTime)
        {
            string url = string.Format("http://api.apirates.com/history/FREE/{0}/EURUSD/{1}", timePeriod,
                fromDateTime.ToUtcEpoch());
            string json = Http.Get(url);
            return JsonConvert.DeserializeObject<List<SymbolBar>>(json, new DateTimeConverter());
        }
    }
}