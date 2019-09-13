using IEXDotNet.IEXDataStructures;
using IEXDotNet.IEXDataStructures.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace IEXDotNet
{
    public class IEXFormatter
    {
        public List<IEXSymbol> FormatIEXSymbols(string iexSymbols)
        {
            List<IEXSymbol> symbolsList = JsonConvert.DeserializeObject<List<IEXSymbol>>(iexSymbols);

            return symbolsList;
        }

        public IEXBalanceSheetList FormatBalanceSheet(string balanceSheet)
        {
            IEXBalanceSheetList balanceSheetList = JsonConvert.DeserializeObject<IEXBalanceSheetList>(balanceSheet);

            return balanceSheetList;
        }

        public IEXIncomeStatementList FormatIncomeStatement(string incomeStatementJson)
        {
            IEXIncomeStatementList incomeStatementList = JsonConvert.DeserializeObject<IEXIncomeStatementList>(incomeStatementJson);

            return incomeStatementList;
        }

        public IEXCashFlowStatementList FormatCashFlowStatement(string cashFlowStatementJson)
        {
            IEXCashFlowStatementList cashFlowStatementList = JsonConvert.DeserializeObject<IEXCashFlowStatementList>(cashFlowStatementJson);

            return cashFlowStatementList;
        }

        public List<string> FormatPeers(string peersJson)
        {
            List<string> cashFlowStatementList = JsonConvert.DeserializeObject<List<string>>(peersJson);

            return cashFlowStatementList;
        }

        public List<IEXHistoricalPrice> FormatHistoricalPrices(string historicalPricesJson)
        {
            List<IEXHistoricalPrice> historicalPrices = JsonConvert.DeserializeObject<List<IEXHistoricalPrice>>(historicalPricesJson);
            return historicalPrices;
        }

        public IEXAccountUsage FormatAccountUsage(string accountUsageJson)
        {
            IEXAccountUsage accountUsage = JsonConvert.DeserializeObject<IEXAccountUsage>(accountUsageJson);
            return accountUsage;
        }

        public List<IexDividend> FormatDividends(string dividendJson)
        {
            List<IexDividend> dividend = JsonConvert.DeserializeObject<List<IexDividend>>(dividendJson);
            return dividend;
        }

        public List<IexDataPoint> FormatDataPoints(string dataPointsJson)
        {
            var utcSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

            List<IexDataPoint> dataPoints = JsonConvert.DeserializeObject<List<IexDataPoint>>(dataPointsJson, utcSettings); // "2019-08-31T08:05:34+00:00"
            return dataPoints;
        }

        public List<IexTimeSeries> FormatTimeSeries(string timeSeriesJson)
        {
            throw new NotImplementedException();
        }

        public List<IexUpcomingEarnings> FormatUpcomingEarnings(string upcomingEarningsJson)
        {
            List<IexUpcomingEarnings> earnings = JsonConvert.DeserializeObject<List<IexUpcomingEarnings>>(upcomingEarningsJson);
            return earnings;
        }

        public IexKeyStats FormatKeyStats(string keyStatsJson)
        {
            IexKeyStats keyStats = JsonConvert.DeserializeObject<IexKeyStats>(keyStatsJson);
            return keyStats;
        }
    }
}
