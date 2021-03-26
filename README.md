# Update on Fundamentals - Jan 2021
IEX has updated their Fundamentals endpoints in 2021 to be called now "Advanced Fundamentals". This advanced fundamentals dataset is a pass-through to [New Constructs](https://client.newconstructs.com/nc/documentation/api.htm). It should be noted that New Constructs is significantly cheaper than IEX, so it is recommended to integrate with New Constructs directly for fundamentals. New constructs covers very large companies, but mid-caps and small-caps are hard to find. If that's the type of thing you're looking for, I'd recommend checking out the [Shardar dataset](https://www.quandl.com/databases/SF1/data) on Quandl.

## IEXDotNet
C# wrapper for IEX APIs. http://iexcloud.io/docs/api/

## Examples
- Initialize a formatter object
```C#
IEXFormatter formatter = new IEXFormatter();
```

- Get IEX Symbols
```C#
IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
string symbols = await client.GetIEXSymbols();
List<IexIexSymbol> symbolsList = formatter.FormatIexIexSymbols(symbols);
```

- Get advanced fundamental data
```C#
IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
string advancedFundamentalsJson = await client.GetTimeSeriesFundamentals("MSFT", "annual", new DateTime(2000, 1, 1), DateTime.Now);
List<IexAdvancedFundamentals> advancedFundamentals = formatter.FormatTimeSeriesFundamentals(advancedFundamentalsJson);
```

- Get historical prices
```C#
IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
string historicalPricesJson = await client.GetHistoricalPrices("msft", "5d");
// string result = await client.GetHistoricalPrices("msft", "5d", chartCloseOnly: true);
List<IEXHistoricalPrice> historicalPrices = formatter.FormatHistoricalPrices(historicalPricesJson);
```

- Get dividends
```C#
IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
string dividend = await client.GetDividends("MSFT", "1y");
List<IexDividend> iexDividend = formatter.FormatDividends(dividend);
```

- Streaming news
```C#
IexSseClient client = new IexSseClient(IEXBaseUrl.SandboxSseUrl, token);
client.NewsEvent += (sender, e) => 
{
    System.Console.WriteLine(e);
};

await client.SubscribeToNewsStream("spy", tokenSource.Token); // Blocking
// client.SubscribeToNewsStream("spy", tokenSource.Token); // Non-blocking
```


See the tests for all examples: [IEXClientTests.cs](../master/IEXDotNet.UnitTests/IEXClientTests.cs) and [IexSscClientTests.cs](../master/IEXDotNet.UnitTests/IexSseClientTests.cs)

## Builds
[![Build Status](https://dev.azure.com/amittleider/IEXDotNet/_apis/build/status/amittleider.IEXDotNet?branchName=master)](https://dev.azure.com/amittleider/IEXDotNet/_build/latest?definitionId=2&branchName=master)

## Nuget package
https://www.nuget.org/packages/IEXDotNet/

## IEX Referral
Consider using me as a referral on IEX by signing up with this link: https://iexcloud.io/s/635df1db 
