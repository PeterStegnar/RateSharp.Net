using System;
using Newtonsoft.Json;
using RateSharp.Net.Models.Enum;

namespace RateSharp.Net.Models
{
    public class SymbolLot
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("updateperiod")]
        public TimePeriod UpdatePeriod { get; set; }

        [JsonProperty("AUDCAD")]
        public SymbolBar AUDCAD { get; set; }

        [JsonProperty("AUDCHF")]
        public SymbolBar AUDCHF { get; set; }

        [JsonProperty("AUDJPY")]
        public SymbolBar AUDJPY { get; set; }

        [JsonProperty("AUDNZD")]
        public SymbolBar AUDNZD { get; set; }

        [JsonProperty("AUDUSD")]
        public SymbolBar AUDUSD { get; set; }

        [JsonProperty("AUS200")]
        public SymbolBar AUS200 { get; set; }

        [JsonProperty("CADCHF")]
        public SymbolBar CADCHF { get; set; }

        [JsonProperty("CADJPY")]
        public SymbolBar CADJPY { get; set; }

        [JsonProperty("CHFJPY")]
        public SymbolBar CHFJPY { get; set; }

        [JsonProperty("ESP35")]
        public SymbolBar ESP35 { get; set; }

        [JsonProperty("EURAUD")]
        public SymbolBar EURAUD { get; set; }

        [JsonProperty("EURCAD")]
        public SymbolBar EURCAD { get; set; }

        [JsonProperty("EURCHF")]
        public SymbolBar EURCHF { get; set; }

        [JsonProperty("EURDKK")]
        public SymbolBar EURDKK { get; set; }

        [JsonProperty("EURGBP")]
        public SymbolBar EURGBP { get; set; }

        [JsonProperty("EURJPY")]
        public SymbolBar EURJPY { get; set; }

        [JsonProperty("EURNOK")]
        public SymbolBar EURNOK { get; set; }

        [JsonProperty("EURNZD")]
        public SymbolBar EURNZD { get; set; }

        [JsonProperty("EURPLN")]
        public SymbolBar EURPLN { get; set; }

        [JsonProperty("EURSEK")]
        public SymbolBar EURSEK { get; set; }

        [JsonProperty("EURTRY")]
        public SymbolBar EURTRY { get; set; }

        [JsonProperty("EURUSD")]
        public SymbolBar EURUSD { get; set; }

        [JsonProperty("FRA40")]
        public SymbolBar FRA40 { get; set; }

        [JsonProperty("GBPAUD")]
        public SymbolBar GBPAUD { get; set; }

        [JsonProperty("GBPCAD")]
        public SymbolBar GBPCAD { get; set; }

        [JsonProperty("GBPCHF")]
        public SymbolBar GBPCHF { get; set; }

        [JsonProperty("GBPJPY")]
        public SymbolBar GBPJPY { get; set; }

        [JsonProperty("GBPNZD")]
        public SymbolBar GBPNZD { get; set; }

        [JsonProperty("GBPUSD")]
        public SymbolBar GBPUSD { get; set; }

        [JsonProperty("GER30")]
        public SymbolBar GER30 { get; set; }

        [JsonProperty("HKG33")]
        public SymbolBar HKG33 { get; set; }

        [JsonProperty("ITA40")]
        public SymbolBar ITA40 { get; set; }

        [JsonProperty("JPN225")]
        public SymbolBar JPN225 { get; set; }

        [JsonProperty("NAS100")]
        public SymbolBar NAS100 { get; set; }

        [JsonProperty("NOKJPY")]
        public SymbolBar NOKJPY { get; set; }

        [JsonProperty("NZDCAD")]
        public SymbolBar NZDCAD { get; set; }

        [JsonProperty("NZDCHF")]
        public SymbolBar NZDCHF { get; set; }

        [JsonProperty("NZDJPY")]
        public SymbolBar NZDJPY { get; set; }

        [JsonProperty("NZDUSD")]
        public SymbolBar NZDUSD { get; set; }

        [JsonProperty("SEKJPY")]
        public SymbolBar SEKJPY { get; set; }

        [JsonProperty("SPX500")]
        public SymbolBar SPX500 { get; set; }

        [JsonProperty("TRYJPY")]
        public SymbolBar TRYJPY { get; set; }

        [JsonProperty("UK100")]
        public SymbolBar UK100 { get; set; }

        [JsonProperty("UKOil")]
        public SymbolBar UKOil { get; set; }

        [JsonProperty("US30")]
        public SymbolBar US30 { get; set; }

        [JsonProperty("USDCAD")]
        public SymbolBar USDCAD { get; set; }

        [JsonProperty("USDCHF")]
        public SymbolBar USDCHF { get; set; }

        [JsonProperty("USDCNH")]
        public SymbolBar USDCNH { get; set; }

        [JsonProperty("USDDKK")]
        public SymbolBar USDDKK { get; set; }

        [JsonProperty("USDHKD")]
        public SymbolBar USDHKD { get; set; }

        [JsonProperty("USDILS")]
        public SymbolBar USDILS { get; set; }

        [JsonProperty("USDJPY")]
        public SymbolBar USDJPY { get; set; }

        [JsonProperty("USDMXN")]
        public SymbolBar USDMXN { get; set; }

        [JsonProperty("USDNOK")]
        public SymbolBar USDNOK { get; set; }

        [JsonProperty("USDOLLAR")]
        public SymbolBar USDOLLAR { get; set; }

        [JsonProperty("USDPLN")]
        public SymbolBar USDPLN { get; set; }

        [JsonProperty("USDSEK")]
        public SymbolBar USDSEK { get; set; }

        [JsonProperty("USDSGD")]
        public SymbolBar USDSGD { get; set; }

        [JsonProperty("USDTRY")]
        public SymbolBar USDTRY { get; set; }

        [JsonProperty("USDZAR")]
        public SymbolBar USDZAR { get; set; }

        [JsonProperty("USOil")]
        public SymbolBar USOil { get; set; }

        [JsonProperty("XAGUSD")]
        public SymbolBar XAGUSD { get; set; }

        [JsonProperty("XAUUSD")]
        public SymbolBar XAUUSD { get; set; }

        [JsonProperty("XPDUSD")]
        public SymbolBar XPDUSD { get; set; }

        [JsonProperty("XPTUSD")]
        public SymbolBar XPTUSD { get; set; }
    }
}