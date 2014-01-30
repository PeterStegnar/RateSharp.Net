RateSharp.Net
=============
### RateSharp.Net is a C# library for [APIRates](http://apirates.com), a real-time FOREX API.

###### Pricing data provided in the API instance are valid real-time data from markets, but meant for testing purposes only.
###### You can use it at your own responsibility.


# Examples 

##### There are two seperate classes in this library:
-  `RatesDedi.cs` is for clients who own an APIKey from APIRates.com,
-  `RatesLite.cs` is for users who wish to simply test the API, and can access the `EURUSD` symbol alone.

---
#### RatesLite
##### The examples below are demonstrating the `RatesLite` class.

-
###### Retrieves the most recent update on the symbol `EURUSD` and prints to console.

    var bar = RatesLite.GetBarUpdate(TimePeriod.M1);

    Console.WriteLine("Open:       {0}", bar.Open);
    Console.WriteLine("Close:      {0}", bar.Close);
    Console.WriteLine("High:       {0}", bar.High);
    Console.WriteLine("Low:        {0}", bar.Low);
    Console.WriteLine("Time stamp: {0}", bar.Timestamp);

-
###### Retrieves the pricing data on all time periods for the `EURUSD` symbol, I've also used reflection to iterate through the type members in the example below.

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

-

###### Retrieves the pricing history on the symbol `EURUSD`.

    var symbolHistory = RatesLite.GetBarHistory(TimePeriod.M5, DateTime.UtcNow.Subtract(TimeSpan.FromHours(1)));

    foreach (var symbolBar in symbolHistory)
    {
        Console.WriteLine("Open:       {0}", symbolBar.Open);
        Console.WriteLine("Close:      {0}", symbolBar.Close);
        Console.WriteLine("High:       {0}", symbolBar.High);
        Console.WriteLine("Low:        {0}", symbolBar.Low);
        Console.WriteLine("Time stamp: {0}\n", symbolBar.Timestamp);
    }

---
#### RatesDedi
##### The examples below are demonstrating the `RatesDedi` class.
    
-

###### Retrieves the pricing data on a specified time period for the specified symbol  

    var bar = RatesDedi.GetBarUpdate(ApiKey, TimePeriod.M5, Symbol.EURGBP);

    Console.WriteLine("Open:       {0}", bar.Open);
    Console.WriteLine("Close:      {0}", bar.Close);
    Console.WriteLine("High:       {0}", bar.High);
    Console.WriteLine("Low:        {0}", bar.Low);
    Console.WriteLine("Time stamp: {0}", bar.Timestamp);
    

-
  
###### Retrieves the pricing data for every symbol.

    var symbols = RatesDedi.GetLotUpdate(ApiKey, TimePeriod.M60);

    Console.WriteLine("Time Period:      {0}", symbols.UpdatePeriod);
    Console.WriteLine("Time Stamp:       {0}", symbols.Timestamp);
    Console.WriteLine(">>> GBPCHF");
    Console.WriteLine(">>> Open:         {0}", symbols.GBPCHF.Open);
    Console.WriteLine(">>> Close:        {0}", symbols.GBPCHF.Close);
    Console.WriteLine(">>> High:         {0}", symbols.GBPCHF.High);
    Console.WriteLine(">>> Low:          {0}", symbols.GBPCHF.Low);


-

###### Retrieves the specified symbols history.
    
    var symbolHistory = RatesDedi.GetBarHistory(ApiKey, TimePeriod.M5, Symbol.EURGBP, DateTime.UtcNow.Subtract(TimeSpan.FromHours(1)));
 
    foreach (var symbolBar in symbolHistory)
    {
        Console.WriteLine("Open:       {0}", symbolBar.Open);
        Console.WriteLine("Close:      {0}", symbolBar.Close);
        Console.WriteLine("High:       {0}", symbolBar.High);
        Console.WriteLine("Low:        {0}", symbolBar.Low);
        Console.WriteLine("Time stamp: {0}\n", symbolBar.Timestamp);
    }
    
-

###### Retrieves the pricing data on all time periods for the specified symbol. (The method below is using reflection to iterate through all of its properties.

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


[![Bitdeli Badge](https://d2weczhvl823v0.cloudfront.net/AydinAdn/ratesharp.net/trend.png)](https://bitdeli.com/free "Bitdeli Badge")

