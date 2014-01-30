using System;
using System.Diagnostics;
using NUnit.Framework;

using RateSharp.Net.Models.Enum;
using RateSharp.Net.Models;

namespace RateSharp.Net.Test
{
    [TestFixture]
    public class RateTest
    {
        [TestFixtureSetUp]
        public void Init()
        {
         /* Enter your API Key below.
          * ******************************************/
            const string apiKey = "";
         /* ******************************************/

            var day = DateTime.UtcNow.DayOfWeek;
            var hour = DateTime.UtcNow.Hour;

            switch (day)
            {
                case DayOfWeek.Friday:
                    if (hour > 22) Debug.Assert(false, "Markets are closed!", "Markets reopen on Sunday 22:00 UTC");
                    break;

                case DayOfWeek.Saturday:
                    Debug.Assert(false, "Markets are closed!", "Markets reopen on Sunday 22:00 UTC");
                    break;

                case DayOfWeek.Sunday:
                    if (hour < 22) Debug.Assert(false, "Markets are closed!", "Markets reopen on Sunday 22:00 UTC");
                    break;
            }

            _rates = new Rates(apiKey);
        }

        private Rates _rates;

        [TestCase]
        public void Can_GetBarUpdate()
        {
            var bar = _rates.GetBarUpdate(TimePeriod.M5, Symbol.EURNOK);
            Debug.Assert(bar.Open != 0, "Open price is invalid");
            Debug.Assert(bar.Close != 0, "Close price is invalid");
            Debug.Assert(bar.High != 0, "High price is invalid");
            Debug.Assert(bar.Low != 0, "Low price is invalid");
            Debug.Assert(bar.Timestamp > DateTime.UtcNow.Subtract(TimeSpan.FromDays(365)));

            Console.WriteLine("Open: {0}", bar.Open);
            Console.WriteLine("Close: {0}", bar.Close);
            Console.WriteLine("High: {0}", bar.High);
            Console.WriteLine("Low: {0}", bar.Low);
            Console.WriteLine("Time stamp: {0}\n", bar.Timestamp);
        }

        [TestCase]
        public void Can_GetLotUpdate()
        {
            var allSymbols = _rates.GetLotUpdate(TimePeriod.M60);
            var periodProperties = allSymbols.GetType().GetProperties();

            foreach (var property in periodProperties)
            {
                if (!(property.GetValue(allSymbols) is SymbolBar)) continue;

                var bar = (SymbolBar)property.GetValue(allSymbols);
                bar.Timestamp = allSymbols.Timestamp;

                Debug.Assert(bar.Open != 0, "Open price is invalid");
                Debug.Assert(bar.Close != 0, "Close price is invalid");
                Debug.Assert(bar.High != 0, "High price is invalid");
                Debug.Assert(bar.Low != 0, "Low price is invalid");
                Debug.Assert(bar.Timestamp > DateTime.UtcNow.Subtract(TimeSpan.FromDays(365)));

                Console.WriteLine(property.Name);
                Console.WriteLine("Open: {0}", bar.Open);
                Console.WriteLine("Close: {0}", bar.Close);
                Console.WriteLine("High: {0}", bar.High);
                Console.WriteLine("Low: {0}", bar.Low);
                Console.WriteLine("Time stamp: {0}\n", bar.Timestamp);
            }
        }

        [TestCase]
        public void Can_GetBarHistory()
        {
            var symbolHistory = _rates.GetBarHistory(TimePeriod.M1, Symbol.TRYJPY, DateTime.Now.Subtract(new TimeSpan(1,0,0,0)));

            foreach (var bar in symbolHistory)
            {
                Debug.Assert(bar.Open != 0, "Open price is invalid");
                Debug.Assert(bar.Close != 0, "Close price is invalid");
                Debug.Assert(bar.High != 0, "High price is invalid");
                Debug.Assert(bar.Low != 0, "Low price is invalid");
                Debug.Assert(bar.Timestamp > DateTime.UtcNow.Subtract(TimeSpan.FromDays(365)));

                Console.WriteLine("Open: {0}", bar.Open);
                Console.WriteLine("Close: {0}", bar.Close);
                Console.WriteLine("High: {0}", bar.High);
                Console.WriteLine("Low: {0}", bar.Low);
                Console.WriteLine("Time stamp: {0}\n", bar.Timestamp);
            }
        }

        [TestCase]
        public void Can_GetAllPeriodsUpdate()
        {
            var periods = _rates.GetAllPeriodsUpdate(Symbol.USDTRY);
            var periodProperties = periods.GetType().GetProperties();

            foreach (var property in periodProperties)
            {
                var bar = (SymbolBar)property.GetValue(periods);
                
                Debug.Assert(bar.Open  != 0, "Open price is invalid");
                Debug.Assert(bar.Close != 0, "Close price is invalid");
                Debug.Assert(bar.High  != 0, "High price is invalid");
                Debug.Assert(bar.Low   != 0, "Low price is invalid");
                Debug.Assert(bar.Timestamp > DateTime.UtcNow.Subtract(TimeSpan.FromDays(365)));

                Console.WriteLine(property.Name);
                Console.WriteLine("Open: {0}", bar.Open);
                Console.WriteLine("Close: {0}", bar.Close);
                Console.WriteLine("High: {0}", bar.High);
                Console.WriteLine("Low: {0}", bar.Low);
                Console.WriteLine("Time stamp: {0}\n", bar.Timestamp);
            }
        }
    }
}
