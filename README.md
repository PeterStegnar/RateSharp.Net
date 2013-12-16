RateSharp.Net
=============
RateSharp.Net is a C# library for [APIRates](http://apirates.com), a real-time FOREX API.


# Examples 
The examples below are demonstrating the RatesLite class which can only retrieve data on the EURUSD symbol.
It's meant for testing purposes only.

Retrieves the most recent update on the symbol EURUSD and prints to console.

    var bar = RatesLite.GetBarUpdate(TimePeriod.M1);

    Console.WriteLine("Open:       {0}", bar.Open);
    Console.WriteLine("Close:      {0}", bar.Close);
    Console.WriteLine("High:       {0}", bar.High);
    Console.WriteLine("Low:        {0}", bar.Low);
    Console.WriteLine("Time stamp: {0}", bar.Timestamp);;

Retrieves the pricing history on the symbol EURUSD.

    var symbolHistory = RatesLite.GetBarHistory(TimePeriod.M5, DateTime.UtcNow.Subtract(TimeSpan.FromHours(1)));

    foreach (var symbolBar in symbolHistory)
    {
        Console.WriteLine("\nOpen:       {0}", symbolBar.Open);
        Console.WriteLine("Close:      {0}", symbolBar.Close);
        Console.WriteLine("High:       {0}", symbolBar.High);
        Console.WriteLine("Low:        {0}", symbolBar.Low);
        Console.WriteLine("Time stamp: {0}", symbolBar.Timestamp);
    }

