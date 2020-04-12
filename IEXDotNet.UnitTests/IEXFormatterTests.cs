using FluentAssertions;
using IEXDotNet.IEXDataStructures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IEXDotNet.UnitTests
{
    public class IEXFormatterTests
    {
        [Fact]
        public void Should_Format_Symbols()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "Symbols.json")))
            {
                string symbols = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                List<IexSymbol> symbolsList = formatter.FormatSymbols(symbols);

                symbolsList[0].Symbol.Should().Be("A");
                symbolsList[0].Date.Should().Be(new DateTime(2019, 10, 16));
                symbolsList[0].IsEnabled.Should().Be(true);
                symbolsList.Count.Should().Be(8840);
            }
        }

        [Fact]
        public void Should_Format_IEXSymbols()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "AllIEXSymbols.txt")))
            {
                string symbols = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                List<IexIexSymbol> symbolsList = formatter.FormatIexIexSymbols(symbols);

                symbolsList[0].Symbol.Should().Be("A");
                symbolsList[0].Date.Should().Be(new DateTime(2019, 4, 5));
                symbolsList[0].IsEnabled.Should().Be(true);
                symbolsList.Count.Should().Be(8737);
            }
        }

        [Fact]
        public void Should_Format_BalanceSheet()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText/BalanceSheet.txt")))
            {
                string balanceSheetJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                IEXBalanceSheetList balanceSheetList = formatter.FormatBalanceSheet(balanceSheetJson);

                balanceSheetList.Symbol.Should().Be("AAPL");
                balanceSheetList.BalanceSheet.Count.Should().Be(4);

                balanceSheetList.BalanceSheet[0].NetTangibleAssets.Should().Be(120177150156);
                balanceSheetList.BalanceSheet[0].TreasuryStock.Should().BeNull();
            }
        }

        [Fact]
        public void Should_Format_IncomeStatement()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText/IncomeStatement.txt")))
            {
                string incomeStatementJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                IEXIncomeStatementList incomeStatementList = formatter.FormatIncomeStatement(incomeStatementJson);

                incomeStatementList.Symbol.Should().Be("AAPL");
                incomeStatementList.Income.Count.Should().Be(4);

                incomeStatementList.Income[0].TotalRevenue.Should().Be(87741596877);
                incomeStatementList.Income[0].NetIncome.Should().Be(20683606036);
            }
        }

        [Fact]
        public void Should_Format_CashFlowStatement()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText/CashFlowStatement.txt")))
            {
                string cashFlowStatementJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                IEXCashFlowStatementList incomeStatementList = formatter.FormatCashFlowStatement(cashFlowStatementJson);

                incomeStatementList.Symbol.Should().Be("AAPL");
                incomeStatementList.CashFlow.Count.Should().Be(4);

                incomeStatementList.CashFlow[0].CashFlow.Should().Be(26779302494);
                incomeStatementList.CashFlow[0].Depreciation.Should().Be(3514688687);
            }
        }

        [Fact]
        public void Should_Format_GetPeers()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "PeersResponse.txt")))
            {
                string peersJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                List<string> peers = formatter.FormatPeers(peersJson);

                peers.Count.Should().Be(7);
                peers[0].Should().Be("MSFT");
                peers[6].Should().Be("XLK");
            }
        }

        [Fact]
        public void Should_Format_HistoricalPrices()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "HistoricalPrices.txt")))
            {
                string historicalPricesJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                List<IEXHistoricalPrice> historicalPrices = formatter.FormatHistoricalPrices(historicalPricesJson);

                historicalPrices.Count.Should().Be(64);
                historicalPrices[0].open.Should().Be(133.7m);
            }
        }

        [Fact]
        public void Should_Format_AccountUsage()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "AccountUsage.json")))
            {
                string accountUsageJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                IEXAccountUsage accountUsage = formatter.FormatAccountUsage(accountUsageJson);

                accountUsage.Messages.MonthlyUsage.Should().Be(128054);
            }
        }

        [Fact]
        public void Should_Format_Dividend()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "Dividend.json")))
            {
                string dividend = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                List<IexDividend> iexDividend = formatter.FormatDividends(dividend);

                iexDividend.Count.Should().Be(4);
                iexDividend[0].amount.Should().Be(0.47m);
                iexDividend[1].amount.Should().Be(0.48m);
                iexDividend[2].amount.Should().Be(0.47m);
                iexDividend[3].amount.Should().Be(0.48m);

                iexDividend[0].exDate.Should().Be("2019-08-21");
                iexDividend[1].exDate.Should().Be("2019-05-24");
                iexDividend[2].exDate.Should().Be("2019-02-21");
                iexDividend[3].exDate.Should().Be("2018-11-24");
            }
        }

        [Fact]
        public void Should_Format_DataPoints()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "DataPoints.json")))
            {
                string dataPointsJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                List<IexDataPoint> iexDataPoints = formatter.FormatDataPoints(dataPointsJson);

                iexDataPoints.Count.Should().Be(126);
                IexDataPoint latest10k = iexDataPoints.Where(dp => dp.Key == "LATEST-FINANCIAL-ANNUAL-REPORT-DATE").FirstOrDefault();
                IexDataPoint latest10q = iexDataPoints.Where(dp => dp.Key == "LATEST-FINANCIAL-QUARTERLY-REPORT-DATE").FirstOrDefault();

                latest10k.LastUpdated.Should().Be(new DateTime(2019, 8, 31, 8, 5, 34));
                latest10k.Weight.Should().Be(0);

                latest10q.LastUpdated.Should().Be(new DateTime(2019, 8, 31, 8, 13, 25));
                latest10q.Weight.Should().Be(0);
            }
        }

        [Fact]
        public void Should_Format_DataPoints2()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "DataPoints2.json")))
            {
                string dataPointsJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                List<IexDataPoint> iexDataPoints = formatter.FormatDataPoints(dataPointsJson);

                iexDataPoints.Count.Should().Be(1);
                IexDataPoint latest10k = iexDataPoints.Where(dp => dp.Key == "LATEST-FINANCIAL-ANNUAL-REPORT-DATE").FirstOrDefault();

                latest10k.LastUpdated.Should().Be(new DateTime(2019, 8, 31, 8, 5, 34));
                latest10k.Weight.Should().Be(0);
            }
        }

        [Fact]
        public void Should_Format_DataPoints_WithNullDateTimes()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "DataPointsWithNullDateTimes.json")))
            {
                string dataPointsJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                List<IexDataPoint> iexDataPoints = formatter.FormatDataPoints(dataPointsJson);
            }
        }

        [Fact(Skip = "Time series is not implemented")]
        public void Should_Format_TimeSeries()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "TimeSeries.json")))
            {
                string timeSeriesJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                List<IexTimeSeries> iexTimeSeries = formatter.FormatTimeSeries(timeSeriesJson);
            }
        }

        [Fact]
        public void Should_Format_UpcomingEarnings()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "UpcomingEarnings.json")))
            {
                string upcomingEarningsJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                List<IexUpcomingEarnings> iexUpcomingEarnings = formatter.FormatUpcomingEarnings(upcomingEarningsJson);
                iexUpcomingEarnings.Count.Should().Be(1);
                iexUpcomingEarnings[0].Symbol.Should().Be("AAPL");
                iexUpcomingEarnings[0].ReportDate.Should().Be(new DateTime(2019, 11, 09));
            }
        }

        [Fact]
        public void Should_Format_KeyStats()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "KeyStats.json")))
            {
                string keyStatsJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                IexKeyStats keyStats = formatter.FormatKeyStats(keyStatsJson);

                keyStats.CompanyName.Should().Be("Apple Inc.");
                keyStats.SharesOutstanding.Should().Be(5213840000);
                keyStats.Float.Should().Be(5203997571);
            }
        }

        [Fact(Skip = "Employees and datetimes need to be parsed correctly. Skipping this for now.")]
        public void Should_Format_KeyStats2()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "KeyStats2.json")))
            {
                string keyStatsJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                IexKeyStats keyStats = formatter.FormatKeyStats(keyStatsJson);

                keyStats.CompanyName.Should().Be("Apple Inc.");
                keyStats.Employees.Should().Be(null);
                keyStats.ExDividendDate.Should().Be(null);
                keyStats.NextDividendDate.Should().Be(null);
                keyStats.NextEarningsDate.Should().Be(null);
            }
        }

        [Fact]
        public void Should_Format_Company()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "Company.json")))
            {
                string companyJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                IexCompany company = formatter.FormatCompany(companyJson);

                company.Ceo.Should().Be("Timothy Donald Cook");
                company.Tags.Length.Should().Be(2);
                company.Tags[0].Should().Be("Electronic Technology");
                company.Tags[1].Should().Be("Telecommunications Equipment");
                company.Symbol.Should().Be("AAPL");
                company.Employees.Should().Be(132000);
            }
        }

        [Fact]
        public void Should_Format_Company2()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "Company2.json")))
            {
                string companyJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                IexCompany company = formatter.FormatCompany(companyJson);

                company.Symbol.Should().Be("AAAU");
                company.Employees.Should().BeNull();
            }
        }

        [Fact]
        public void Should_Format_TopsLast1()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "TopsLast1.json")))
            {
                string topsLastJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                IexTopsLast topsLast = formatter.FormatTopsLast(topsLastJson).First();

                topsLast.Symbol.Should().Be("MSFT");
                topsLast.Price.Should().Be(171.21);
                topsLast.Size.Should().Be(101);
                topsLast.Time.Should().Be(1662031674818);
            }
        }

        [Fact]
        public void Should_Format_TopsLast2()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "TopsLast2.json")))
            {
                string topsLastJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();

                List<IexTopsLast> topsLast = formatter.FormatTopsLast(topsLastJson);

                topsLast.Count.Should().Be(9838);

                var lastTopsLast = topsLast.Last();
                lastTopsLast.Symbol.Should().Be("GTS");
                lastTopsLast.Price.Should().Be(14.15);
                lastTopsLast.Size.Should().Be(102);
                lastTopsLast.Time.Should().Be(1628083243790);
            }
        }

        [Fact]
        public void Should_Format_CryptoQuotes()
        {
            IEXFormatter formatter = new IEXFormatter();

            using (StreamReader reader = new StreamReader(Path.Combine("IexSseResponseText", "cryptoquotes.json")))
            {
                string cryptoQuoteJson = reader.ReadLine();

                IexCryptoQuote cryptoQuote = formatter.FormatCryptoQuoteLine(cryptoQuoteJson);
                cryptoQuote.Symbol.Should().Be("BTCUSDT");
                cryptoQuote.AskPrice.Should().Be(6970.25);
                cryptoQuote.AskSize.Should().Be(0.075793);
                cryptoQuote.BidPrice.Should().Be(7145);
                cryptoQuote.BidSize.Should().Be(1.718794);
                cryptoQuote.CalculationPrice.Should().Be("realtime");
                cryptoQuote.High.Should().BeNull();
                cryptoQuote.LatestPrice.Should().Be(6874.43);
                cryptoQuote.LatestSource.Should().Be("Real time price");
                cryptoQuote.LatestUpdate.Should().Be(1618359674388);
                cryptoQuote.LatestVolume.Should().BeNull();
                cryptoQuote.Low.Should().BeNull();
                cryptoQuote.PreviousClose.Should().BeNull();
                cryptoQuote.PrimaryExchange.Should().Be("0");
                cryptoQuote.Sector.Should().Be("otcureryncyrcp");
                cryptoQuote.Symbol.Should().Be("BTCUSDT");

                cryptoQuoteJson = reader.ReadLine();
                cryptoQuote = formatter.FormatCryptoQuoteLine(cryptoQuoteJson);

                cryptoQuoteJson = reader.ReadLine();
                cryptoQuote = formatter.FormatCryptoQuoteLine(cryptoQuoteJson);
            }
        }

        [Fact]
        public void Should_Format_NewsEvents()
        {
            IEXFormatter formatter = new IEXFormatter();

            using (StreamReader reader = new StreamReader(Path.Combine("IexSseResponseText", "newsevents.json")))
            {
                string newsEventJson = reader.ReadLine();

                var newsEvent = formatter.FormatNewsLine(newsEventJson);
                newsEvent.Datetime.Should().Be(1545215400000L);
                newsEvent.HasPaywall.Should().BeTrue();
                newsEvent.Headline.Should().NotBeEmpty();
                newsEvent.Image.Should().NotBeEmpty();
                newsEvent.Lang.Should().Be("en");
                newsEvent.Related.Should().Be("AAPL,AMZN,GOOG,GOOGL,MSFT");
                newsEvent.Source.Should().Be("Benzinga");
                newsEvent.Summary.Should().NotBeEmpty();
                newsEvent.Url.Should().NotBeEmpty();
            }
        }
    }
}