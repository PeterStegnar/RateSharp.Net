using System;
using System.Diagnostics;
using NUnit.Framework;
using RateSharp.Net.Free;
using RateSharp.Net.Models;
using RateSharp.Net.Models.Enum;

namespace RateSharp.Net.Test
{
    [TestFixture]
    public class RateFreeTest
    {
        [TestCase]
        public void Can_GetBarUpdate()
        {
            var bar = new Free.Rates().GetBarUpdate(TimePeriod.M10);

            Debug.Assert(bar.Open != 0, "Open price is invalid");
            Debug.Assert(bar.Close != 0, "Close price is invalid");
            Debug.Assert(bar.High != 0, "High price is invalid");
            Debug.Assert(bar.Low != 0, "Low price is invalid");
            Debug.Assert(bar.Timestamp > DateTime.UtcNow.Subtract(TimeSpan.FromDays(365)));

            Console.WriteLine("Open: {0}", bar.Open);
            Console.WriteLine("Close: {0}", bar.Close);
            Console.WriteLine("High: {0}", bar.High);
            Console.WriteLine("Low: {0}", bar.Low);
            Console.WriteLine("Time stamp: {0}", bar.Timestamp);
        }

        [TestCase]
        public void Can_GetAllPeriods()
        {
            var periods = new Free.Rates().GetAllPeriodsUpdate();
            var periodProperties = periods.GetType().GetProperties();

            foreach (var property in periodProperties)
            {
                var bar = (SymbolBar)property.GetValue(periods);

                Debug.Assert(bar.Open != 0, "Open price is invalid");
                Debug.Assert(bar.Close != 0, "Close price is invalid");
                Debug.Assert(bar.High != 0, "High price is invalid");
                Debug.Assert(bar.Low != 0, "Low price is invalid");
                Debug.Assert(bar.Timestamp > DateTime.UtcNow.Subtract(TimeSpan.FromDays(365)));

                Console.WriteLine("Open: {0}", bar.Open);
                Console.WriteLine("Close: {0}", bar.Close);
                Console.WriteLine("High: {0}", bar.High);
                Console.WriteLine("Low: {0}", bar.Low);
                Console.WriteLine("Time stamp: {0}", bar.Timestamp);
            }
        }

        [TestCase]
        public void Can_GetBarHistory()
        {
            var symbolHistory = new Free.Rates().GetBarHistory(TimePeriod.M5, DateTime.UtcNow.Subtract(TimeSpan.FromHours(1)));

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
                Console.WriteLine("Time stamp: {0}", bar.Timestamp);
            }
        }
    }
}
