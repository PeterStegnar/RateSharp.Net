RateSharp.Net
=============
### RateSharp.Net is a C# library for [APIRates](http://apirates.com), a real-time FOREX API.

###### Pricing data provided in the API are valid real-time data from their respective markets, but meant for testing purposes.

# Examples 

##### There are four projects in this solution:
-  `RateSharp.Net` is a class for clients who own an APIKey from APIRates.com,
-  `RateSharp.Net.Free` is for users who wish to test the API, however it does have a limitation, it provides data on the `EURUSD` symbol alone.
-  `RateSharp.Net.Models` contains data models used by both of the previous projects.
-  `RateSharp.Net.Test` 

---
#### RateSharp.Net.Free.Rates
##### The examples below demonstrate how to use the `RateSharp.Net.Free.Rates` class.

-
###### Retrieves the most recent update on the symbol `EURUSD` and prints to console.

    var bar = new Free.Rates().GetBarUpdate(TimePeriod.M10);
    
    Console.WriteLine("Open: {0}", bar.Open);
    Console.WriteLine("Close: {0}", bar.Close);
    Console.WriteLine("High: {0}", bar.High);
    Console.WriteLine("Low: {0}", bar.Low);
    Console.WriteLine("Time stamp: {0}", bar.Timestamp);

-
###### Retrieves the pricing data on all time periods for the `EURUSD` symbol, I've also used reflection to iterate through the type members in the example below.

    var periods = new Free.Rates().GetAllPeriodsUpdate();
    var periodProperties = periods.GetType().GetProperties();

    foreach (var property in periodProperties)
    {
        var bar = (SymbolBar)property.GetValue(periods);

        Console.WriteLine("Open: {0}", bar.Open);
        Console.WriteLine("Close: {0}", bar.Close);
        Console.WriteLine("High: {0}", bar.High);
        Console.WriteLine("Low: {0}", bar.Low);
        Console.WriteLine("Time stamp: {0}", bar.Timestamp);
    }

-

###### Retrieves the pricing history on the symbol `EURUSD`.

    var symbolHistory = new Free.Rates().GetBarHistory(TimePeriod.M5, DateTime.UtcNow.Subtract(TimeSpan.FromHours(1)));

    foreach (var bar in symbolHistory)
    {
        Console.WriteLine("Open: {0}", bar.Open);
        Console.WriteLine("Close: {0}", bar.Close);
        Console.WriteLine("High: {0}", bar.High);
        Console.WriteLine("Low: {0}", bar.Low);
        Console.WriteLine("Time stamp: {0}", bar.Timestamp);
    }

---
#### RateSharp.Net
##### The examples below are demonstrating how to use the `RateSharp.Net.Rates` class. Please note that to use this library you need to have an API Key.
    
-

###### Retrieves the pricing data on a specified time period for the specified symbol  

    
    var bar = new Rates("ApiKey").GetBarUpdate(TimePeriod.M5, Symbol.EURNOK);
    
    Console.WriteLine("Open: {0}", bar.Open);
    Console.WriteLine("Close: {0}", bar.Close);
    Console.WriteLine("High: {0}", bar.High);
    Console.WriteLine("Low: {0}", bar.Low);
    Console.WriteLine("Time stamp: {0}\n", bar.Timestamp);
    

-
  
###### Retrieves the pricing data for every symbol.

    var allSymbols = new Rates("ApiKey").GetLotUpdate(TimePeriod.M60);
    var periodProperties = allSymbols.GetType().GetProperties();

    foreach (var property in periodProperties)
    {
        if (!(property.GetValue(allSymbols) is SymbolBar)) continue;

        var bar = (SymbolBar)property.GetValue(allSymbols);
        bar.Timestamp = allSymbols.Timestamp;

        Console.WriteLine(property.Name);
        Console.WriteLine("Open: {0}", bar.Open);
        Console.WriteLine("Close: {0}", bar.Close);
        Console.WriteLine("High: {0}", bar.High);
        Console.WriteLine("Low: {0}", bar.Low);
        Console.WriteLine("Time stamp: {0}\n", bar.Timestamp);
    }


-

###### Retrieves the specified symbols history.
    
    var symbolHistory = new Rates("ApiKey").GetBarHistory(TimePeriod.M1, Symbol.TRYJPY, DateTime.Now.Subtract(new TimeSpan(1,0,0,0)));

    foreach (var bar in symbolHistory)
    {
        Console.WriteLine("Open: {0}", bar.Open);
        Console.WriteLine("Close: {0}", bar.Close);
        Console.WriteLine("High: {0}", bar.High);
        Console.WriteLine("Low: {0}", bar.Low);
        Console.WriteLine("Time stamp: {0}\n", bar.Timestamp);
    }
    
-

###### Retrieves the pricing data on all time periods for the specified symbol. (The method below is using reflection to iterate through all of its properties.

    var periods = new Rates("ApiKey").GetAllPeriodsUpdate(Symbol.USDTRY);
    var periodProperties = periods.GetType().GetProperties();

    foreach (var property in periodProperties)
    {
        var bar = (SymbolBar)property.GetValue(periods);
        
        Console.WriteLine(property.Name);
        Console.WriteLine("Open: {0}", bar.Open);
        Console.WriteLine("Close: {0}", bar.Close);
        Console.WriteLine("High: {0}", bar.High);
        Console.WriteLine("Low: {0}", bar.Low);
        Console.WriteLine("Time stamp: {0}\n", bar.Timestamp);
    }


[![Bitdeli Badge](https://d2weczhvl823v0.cloudfront.net/AydinAdn/ratesharp.net/trend.png)](https://bitdeli.com/free "Bitdeli Badge")

