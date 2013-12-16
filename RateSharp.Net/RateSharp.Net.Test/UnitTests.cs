//  ***********************************************************************
//   Solution	: RateSharp.Net
//   Project	: RateSharp.Net.Test
//   Author		: F Aydin
//   Created	: 23:14, 15:12:2013
//    
//   Last Modified By	: F Aydin
//   Last Modified On 	: 01:14, 16:12:2013
//  ***********************************************************************

using System;
using System.Diagnostics;

using NUnit.Framework;

using RateSharp.Net.Enums;
using RateSharp.Net.Models;
using RateSharp.Net.Util;

namespace RateSharp.Net.Test
{
    [TestFixture]
    public class UnitTests
    {
        public string ApiKey = "";

        #region WebRequest
        [TestCase]
        public void Can_Get_Json_WebResponse()
        {
            var json = Web.Get("http://api.apirates.com/update/FREE/M1/EURUSD");

            Debug.Assert(!json.StartsWith("Error:"), json);

            Console.WriteLine("HttpWebResponse:\n\n{0}", json);
        }
        #endregion  

        #region Lite
        [TestCase]
        public void Can_Get_Bar_Update_Free()
        {
            var bar = RatesLite.GetBarUpdate(TimePeriod.M1);

            Console.WriteLine("Open:       {0}", bar.Open);
            Console.WriteLine("Close:      {0}", bar.Close);
            Console.WriteLine("High:       {0}", bar.High);
            Console.WriteLine("Low:        {0}", bar.Low);
            Console.WriteLine("Time stamp: {0}", bar.Timestamp);
        }

        [TestCase]
        public void Can_Get_All_Periods_Free()
        {
            var periods          = RatesLite.GetAllPeriodsUpdate();
            var periodProperties = periods.GetType().GetProperties();

            foreach (var property in periodProperties)
            {
                var bar = (SymbolBar) property.GetValue(periods);

                Console.WriteLine("Period:     {0}", property.Name);
                Console.WriteLine("Open:       {0}", bar.Open);
                Console.WriteLine("Close:      {0}", bar.Close);
                Console.WriteLine("High:       {0}", bar.High);
                Console.WriteLine("Low:        {0}", bar.Low);
                Console.WriteLine("Time stamp: {0}\n", bar.Timestamp);
            }
        }

        [TestCase]
        public void Can_Get_Bar_History_Free()
        {
            var symbolHistory = RatesLite.GetBarHistory(TimePeriod.M5, DateTime.UtcNow.Subtract(TimeSpan.FromHours(1)));

            foreach (var symbolBar in symbolHistory)
            {
                Console.WriteLine("\nOpen:       {0}", symbolBar.Open);
                Console.WriteLine("Close:      {0}", symbolBar.Close);
                Console.WriteLine("High:       {0}", symbolBar.High);
                Console.WriteLine("Low:        {0}", symbolBar.Low);
                Console.WriteLine("Time stamp: {0}", symbolBar.Timestamp);
            }
        }
        #endregion

        #region Dedicated 
        [TestCase]
        public void Can_Get_Bar_Update_Dedi()
        {
            var bar = RatesDedi.GetBarUpdate(ApiKey, TimePeriod.M5, Symbol.EURNOK);

            Console.WriteLine("Open:       {0}", bar.Open);
            Console.WriteLine("Close:      {0}", bar.Close);
            Console.WriteLine("High:       {0}", bar.High);
            Console.WriteLine("Low:        {0}", bar.Low);
            Console.WriteLine("Time stamp: {0}", bar.Timestamp);
        }

        [TestCase]
        public void Can_Get_Lot_Update_Dedi()
        {
            var symbols = RatesDedi.GetLotUpdate(ApiKey, TimePeriod.M60);

            Console.WriteLine("Time Period:      {0}", symbols.UpdatePeriod);
            Console.WriteLine("Time Stamp:       {0}", symbols.Timestamp);
            Console.WriteLine(">>> GBPCHF");
            Console.WriteLine(">>> Open:         {0}", symbols.GBPCHF.Open);
            Console.WriteLine(">>> Close:        {0}", symbols.GBPCHF.Close);
            Console.WriteLine(">>> High:         {0}", symbols.GBPCHF.High);
            Console.WriteLine(">>> Low:          {0}", symbols.GBPCHF.Low);
        }

        [TestCase]
        public void Can_Get_Bar_History_Dedi()
        {
            var symbolHistory = RatesDedi.GetBarHistory(ApiKey, TimePeriod.M5, Symbol.EURGBP, DateTime.UtcNow.Subtract(TimeSpan.FromHours(1)));

            foreach (var symbolBar in symbolHistory)
            {
                Console.WriteLine("\nOpen:       {0}", symbolBar.Open);
                Console.WriteLine("Close:      {0}", symbolBar.Close);
                Console.WriteLine("High:       {0}", symbolBar.High);
                Console.WriteLine("Low:        {0}", symbolBar.Low);
                Console.WriteLine("Time stamp: {0}", symbolBar.Timestamp);
            }
        }

        [TestCase]
        public void Can_Get_All_Periods_Update_Dedi()
        {
            var periods = RatesDedi.GetAllPeriodsUpdate(ApiKey, Symbol.EURGBP);
            var periodProperties = periods.GetType().GetProperties();

            foreach (var property in periodProperties)
            {
                var bar = (SymbolBar)property.GetValue(periods);

                Console.WriteLine("Period:     {0}", property.Name);
                Console.WriteLine("Open:       {0}", bar.Open);
                Console.WriteLine("Close:      {0}", bar.Close);
                Console.WriteLine("High:       {0}", bar.High);
                Console.WriteLine("Low:        {0}", bar.Low);
                Console.WriteLine("Time stamp: {0}\n", bar.Timestamp);
            }
        }
        #endregion

    }
}
