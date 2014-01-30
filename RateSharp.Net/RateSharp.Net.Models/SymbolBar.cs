using System;
using Newtonsoft.Json;

namespace RateSharp.Net.Models
{
    public class SymbolBar
    {
        [JsonProperty("close")]
        public decimal Close { get; set; }

        [JsonProperty("high")]
        public decimal High { get; set; }

        [JsonProperty("low")]
        public decimal Low { get; set; }

        [JsonProperty("open")]
        public decimal Open { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}