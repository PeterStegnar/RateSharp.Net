//  ***********************************************************************
//   Solution	: RateSharp.Net
//   Project	: RateSharp.Net
//   Author		: F Aydin
//   Created	: 01:34, 16:12:2013
//    
//   Last Modified By	: F Aydin
//   Last Modified On 	: 11:16, 16:12:2013
//  ***********************************************************************

using Newtonsoft.Json;

namespace RateSharp.Net.Models
{
    public class Period
    {
        [JsonProperty("M1")]
        public SymbolBar M1 { get; set; }

        [JsonProperty("M5")]
        public SymbolBar M5 { get; set; }
        
        [JsonProperty("M10")]
        public SymbolBar M10 { get; set; }

        [JsonProperty("M15")]
        public SymbolBar M15 { get; set; }

        [JsonProperty("M30")]
        public SymbolBar M30 { get; set; }

        [JsonProperty("M60")]
        public SymbolBar M60 { get; set; }
    }
}
