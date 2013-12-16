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
        [TestCase]
        public void Can_Get_Json_WebResponse()
        {
            var json = Web.Get("http://api.apirates.com/update/FREE/M1/EURUSD");

            Debug.Assert(!json.StartsWith("Error:"), json);

            Console.WriteLine("HttpWebResponse:\n\n{0}", json);
        }

        [TestCase]
        public void Can_Deserialize_Bar()
        {
            var bar = new Rates().Get(TimePeriod.M1, Symbol.USDCAD);

            Console.WriteLine("Open:       {0}", bar.Open);
            Console.WriteLine("Close:      {0}", bar.Close);
            Console.WriteLine("High:       {0}", bar.High);
            Console.WriteLine("Low:        {0}", bar.Low);
            Console.WriteLine("Time stamp: {0}", bar.Timestamp);
        }

        [TestCase]
        public void Can_Deserialize_All_Periods()
        {
            var periods = new Rates().GetAll(Symbol.USDCAD);
            var periodProperties = periods.GetType().GetProperties();

            foreach (var property in periodProperties)
            {
                var bar = (Bar) property.GetValue(periods);

                Console.WriteLine("Period:     {0}", property.Name);
                Console.WriteLine("Open:       {0}", bar.Open);
                Console.WriteLine("Close:      {0}", bar.Close);
                Console.WriteLine("High:       {0}", bar.High);
                Console.WriteLine("Low:        {0}", bar.Low);
                Console.WriteLine("Time stamp: {0}\n", bar.Timestamp);
            }
        }
    }
}
