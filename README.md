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

- Get balance sheet data
```C#
IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
string balanceSheetJson = await client.GetBalanceSheet("AAPL", 4, "quarter");
IEXBalanceSheetList balanceSheetList = formatter.FormatBalanceSheet(balanceSheetJson);
```

- Get income statement
```C#
IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
string incomeStatementJson = await client.GetIncomeStatement("AAPL", 4, "quarter");
IEXIncomeStatementList incomeStatementList = formatter.FormatIncomeStatement(incomeStatementJson);
```

- Get upcoming earnings
```C#
IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
string upcomingEarningsJson = await client.GetUpcomingEarnings("AAPL");
List<IexUpcomingEarnings> iexUpcomingEarnings = formatter.FormatUpcomingEarnings(upcomingEarningsJson);
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