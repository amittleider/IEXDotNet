using IEXDotNet.IEXDataStructures;
using IEXDotNet.IEXDataStructures.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IEXDotNet
{
    public class IEXFormatter
    {
        public List<IexIexSymbol> FormatIexIexSymbols(string iexIexSymbols)
        {
            List<IexIexSymbol> symbolsList = JsonConvert.DeserializeObject<List<IexIexSymbol>>(iexIexSymbols);

            return symbolsList;
        }

        public IEXBalanceSheetList FormatBalanceSheet(string balanceSheet)
        {
            IEXBalanceSheetList balanceSheetList = JsonConvert.DeserializeObject<IEXBalanceSheetList>(balanceSheet);

            return balanceSheetList;
        }

        public List<IexSymbol> FormatSymbols(string symbols)
        {
            List<IexSymbol> iexSymbols = JsonConvert.DeserializeObject<List<IexSymbol>>(symbols);

            return iexSymbols;
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

        public List<IexNews> FormatNewsLine(string line)
        {
            return JsonConvert.DeserializeObject<List<IexNews>>(line);
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

        public IexCompany FormatCompany(string companyJson)
        {
            IexCompany company = JsonConvert.DeserializeObject<IexCompany>(companyJson);
            return company;
        }

        public List<IexTopsLast> FormatTopsLast(string topsLastJson)
        {
            List<IexTopsLast> topsLast = JsonConvert.DeserializeObject<List<IexTopsLast>>(topsLastJson);
            return topsLast;
        }

        public List<IexCryptoQuote> FormatCryptoQuoteLine(string cryptoQuoteJson)
        {
            List<IexCryptoQuote> iexCryptoQuotes = JsonConvert.DeserializeObject<List<IexCryptoQuote>>(cryptoQuoteJson);
            return iexCryptoQuotes;
        }
    }
}
