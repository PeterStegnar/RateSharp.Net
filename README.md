RateSharp.Net
=============
RateSharp.Net is a C# library for [APIRates](http://apirates.com), a real-time FOREX API.

***
# Examples
Retrieves the most recent update on the USDCAD pair on the 1M period and prints to console.

    Bar bar = Rates.Get(TimePeriod.M1, Symbol.USDCAD);
    
    Console.WriteLine("Open:       {0}", bar.Open);
    Console.WriteLine("Close:      {0}", bar.Close);
    Console.WriteLine("High:       {0}", bar.High);
    Console.WriteLine("Low:        {0}", bar.Low);
    Console.WriteLine("Time stamp: {0}", bar.Timestamp);

Retrieves the most recent update on USDCAD pair on **all** periods and prints to console.

    Period periods = Rates.GetAll(Symbol.USDCAD);
    PropertyInfo[] periodProperties = periods.GetType().GetProperties();

    foreach (PropertyInfo property in periodProperties)
    {
        Bar bar = (Bar) property.GetValue(periods);

        Console.WriteLine("Period:     {0}", property.Name);
        Console.WriteLine("Open:       {0}", bar.Open);
        Console.WriteLine("Close:      {0}", bar.Close);
        Console.WriteLine("High:       {0}", bar.High);
        Console.WriteLine("Low:        {0}", bar.Low);
        Console.WriteLine("Time stamp: {0}\n", bar.Timestamp);
    }

