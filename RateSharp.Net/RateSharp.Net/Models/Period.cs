//  ***********************************************************************
//   Solution	: RateSharp.Net
//   Project	: RateSharp.Net
//   Author		: F Aydin
//   Created	: 23:08, 15:12:2013
//    
//   Last Modified By	: F Aydin
//   Last Modified On 	: 00:51, 16:12:2013
//  ***********************************************************************

using Newtonsoft.Json;

namespace RateSharp.Net.Models
{
    public class Period
    {
        [JsonProperty("M1")]
        public Bar M1 { get; set; }

        [JsonProperty("M10")]
        public Bar M10 { get; set; }

        [JsonProperty("M15")]
        public Bar M15 { get; set; }

        [JsonProperty("M30")]
        public Bar M30 { get; set; }
        [JsonProperty("M5")]
        public Bar M5 { get; set; }

        [JsonProperty("M60")]
        public Bar M60 { get; set; }
    }
}
