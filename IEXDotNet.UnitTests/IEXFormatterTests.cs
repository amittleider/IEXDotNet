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

        [Fact]
        public void Should_Format_SingleDataPoint()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "SingleDataPoint.json")))
            {
                string dataPointJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                DateTime lastUpdated = formatter.FormatDataPoint(dataPointJson);
                lastUpdated.Should().Be(new DateTime(2020, 6, 30));
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
        public void Should_Format_KeyStats3()
        {
            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "KeyStats3.json")))
            {
                string keyStatsJson = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                IexKeyStats keyStats = formatter.FormatKeyStats(keyStatsJson);

                keyStats.CompanyName.Should().Be("Ormat Technologies Inc");
                keyStats.Avg10Volume.Should().Be(491633);
                keyStats.ExDividendDate.Should().Be(DateTime.MinValue);
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

                List<IexCryptoQuote> cryptoQuotes = formatter.FormatCryptoQuoteLine(cryptoQuoteJson);
                cryptoQuotes[0].Symbol.Should().Be("BTCUSDT");
                cryptoQuotes[0].AskPrice.Should().Be(6970.25);
                cryptoQuotes[0].AskSize.Should().Be(0.075793);
                cryptoQuotes[0].BidPrice.Should().Be(7145);
                cryptoQuotes[0].BidSize.Should().Be(1.718794);
                cryptoQuotes[0].CalculationPrice.Should().Be("realtime");
                cryptoQuotes[0].High.Should().BeNull();
                cryptoQuotes[0].LatestPrice.Should().Be(6874.43);
                cryptoQuotes[0].LatestSource.Should().Be("Real time price");
                cryptoQuotes[0].LatestUpdate.Should().Be(1618359674388);
                cryptoQuotes[0].LatestVolume.Should().BeNull();
                cryptoQuotes[0].Low.Should().BeNull();
                cryptoQuotes[0].PreviousClose.Should().BeNull();
                cryptoQuotes[0].PrimaryExchange.Should().Be("0");
                cryptoQuotes[0].Sector.Should().Be("otcureryncyrcp");
                cryptoQuotes[0].Symbol.Should().Be("BTCUSDT");

                cryptoQuoteJson = reader.ReadLine();
                cryptoQuotes = formatter.FormatCryptoQuoteLine(cryptoQuoteJson);

                cryptoQuoteJson = reader.ReadLine();
                cryptoQuotes = formatter.FormatCryptoQuoteLine(cryptoQuoteJson);
            }
        }

        [Fact]
        public void Should_Format_NewsEvents()
        {
            IEXFormatter formatter = new IEXFormatter();

            using (StreamReader reader = new StreamReader(Path.Combine("IexSseResponseText", "newsevents.json")))
            {
                string newsEventJson = reader.ReadLine();

                var newsEvents = formatter.FormatNewsLine(newsEventJson);
                newsEvents[0].Datetime.Should().Be(1545215400000L);
                newsEvents[0].HasPaywall.Should().BeTrue();
                newsEvents[0].Headline.Should().NotBeEmpty();
                newsEvents[0].Image.Should().NotBeEmpty();
                newsEvents[0].Lang.Should().Be("en");
                newsEvents[0].Related.Should().Be("AAPL,AMZN,GOOG,GOOGL,MSFT");
                newsEvents[0].Source.Should().Be("Benzinga");
                newsEvents[0].Summary.Should().NotBeEmpty();
                newsEvents[0].Url.Should().NotBeEmpty();
            }
        }

        [Fact]
        public void Should_Format_TimeSeriesFundamentals()
        {
            IEXFormatter formatter = new IEXFormatter();

            using (StreamReader reader = new StreamReader(Path.Combine("IEXResponseText", "TimeSeriesFundamentals.json")))
            {
                string advancedFundamentalsJson = reader.ReadLine();

                List<IexAdvancedFundamentals> advancedFundamentals = formatter.FormatTimeSeriesFundamentals(advancedFundamentalsJson);

                advancedFundamentals.Count.Should().Be(125);

                advancedFundamentals[0].AccountsPayable.Should().Be(1095671180);
                advancedFundamentals[0].AccountsPayableTurnover.Should().Be(22.189243428275);
                advancedFundamentals[0].AccountsReceivable.Should().Be(3263373562);
                advancedFundamentals[0].AccountsReceivableTurnover.Should().Be(7.12195066683242);
                advancedFundamentals[0].AsOfDate.Should().Be(new DateTime(2000, 09, 22));
                advancedFundamentals[0].AssetsCurrentCash.Should().Be(24944558998);
                advancedFundamentals[0].AssetsCurrentCashRestricted.Should().Be(0);
                advancedFundamentals[0].AssetsCurrentDeferredCompensation.Should().Be(0);
                advancedFundamentals[0].AssetsCurrentDeferredTax.Should().Be(1716790839);
                advancedFundamentals[0].AssetsCurrentDiscontinuedOperations.Should().Be(0);
                advancedFundamentals[0].AssetsCurrentInvestments.Should().Be(0);
                advancedFundamentals[0].AssetsCurrentLeasesOperating.Should().Be(0);
                advancedFundamentals[0].AssetsCurrentLoansNet.Should().Be(0);
                advancedFundamentals[0].AssetsCurrentOther.Should().Be(1603035750);
                advancedFundamentals[0].AssetsCurrentSeparateAccounts.Should().Be(0);
                advancedFundamentals[0].AssetsCurrentUnadjusted.Should().Be(31804373456);
                advancedFundamentals[0].AssetsFixed.Should().Be(22087936390);
                advancedFundamentals[0].AssetsFixedDeferredCompensation.Should().Be(0);
                advancedFundamentals[0].AssetsFixedDeferredTax.Should().Be(0);
                advancedFundamentals[0].AssetsFixedDiscontinuedOperations.Should().Be(0);
                advancedFundamentals[0].AssetsFixedLeasesOperating.Should().Be(0);
                advancedFundamentals[0].AssetsFixedOperatingDiscontinuedOperations.Should().Be(0);
                advancedFundamentals[0].AssetsFixedOperatingSubsidiaryUnconsolidated.Should().Be(0);
                advancedFundamentals[0].AssetsFixedOreo.Should().Be(0);
                advancedFundamentals[0].AssetsFixedOther.Should().Be(2295214900);
                advancedFundamentals[0].AssetsFixedUnconsolidated.Should().Be(0);
                advancedFundamentals[0].AssetsUnadjusted.Should().Be(53181057889);
                advancedFundamentals[0].Capex.Should().Be(0);
                advancedFundamentals[0].CapexAcquisition.Should().Be(0);
                advancedFundamentals[0].CapexMaintenance.Should().Be(0);
                advancedFundamentals[0].CashConversionCycle.Should().Be(-43.6686002826987);
                advancedFundamentals[0].CashFlowFinancing.Should().Be(-2244631413);
                advancedFundamentals[0].CashFlowInvesting.Should().Be(-12446022212);
                advancedFundamentals[0].CashFlowOperating.Should().Be(14290423920);
                advancedFundamentals[0].CashFlowShareRepurchase.Should().Be(0);
                advancedFundamentals[0].CashLongTerm.Should().Be(18556224574);
                advancedFundamentals[0].CashOperating.Should().Be(0);
                advancedFundamentals[0].CashPaidForIncomeTaxes.Should().Be(0);
                advancedFundamentals[0].CashPaidForInterest.Should().Be(0);
                advancedFundamentals[0].CashRestricted.Should().Be(0);
                advancedFundamentals[0].ChargeAfterTax.Should().Be(0);
                advancedFundamentals[0].ChargeAfterTaxDiscontinuedOperations.Should().Be(0);
                advancedFundamentals[0].ChargesAfterTaxOther.Should().Be(0);
                advancedFundamentals[0].Cik.Should().Be("802010");
                advancedFundamentals[0].CreditLossProvision.Should().Be(0);
                advancedFundamentals[0].DataGenerationDate.Should().Be(new DateTime(2000, 9, 22));
                advancedFundamentals[0].DaysInAccountsPayable.Should().Be(17.6159753855746);
                advancedFundamentals[0].DaysInInventory.Should().Be(0);
                advancedFundamentals[0].DaysInRevenueDeferred.Should().Be(79.1919718879045);
                advancedFundamentals[0].DaysRevenueOutstanding.Should().Be(54.1720696085545);
                advancedFundamentals[0].DebtFinancial.Should().Be(0);
                advancedFundamentals[0].DebtShortTerm.Should().Be(0);
                advancedFundamentals[0].DepreciationAndAmortizationAccumulated.Should().Be(2465657087);
                advancedFundamentals[0].DepreciationAndAmortizationCashFlow.Should().Be(0);
                advancedFundamentals[0].DividendsPreferred.Should().Be(0);
                advancedFundamentals[0].DividendsPreferredRedeemableMandatorily.Should().Be(0);
                advancedFundamentals[0].EarningsRetained.Should().Be(0);
                advancedFundamentals[0].EbitReported.Should().Be(11368438545);
                advancedFundamentals[0].EbitdaReported.Should().Be(10985863946);
                advancedFundamentals[0].EquityShareholder.Should().Be(42609388771);
                advancedFundamentals[0].EquityShareholderOther.Should().Be(41157614266);
                advancedFundamentals[0].EquityShareholderOtherDeferredCompensation.Should().Be(0);
                advancedFundamentals[0].EquityShareholderOtherEquity.Should().Be(41123661177);
                advancedFundamentals[0].EquityShareholderOtherMezzanine.Should().Be(0);
                advancedFundamentals[0].Expenses.Should().Be(8982791754);
                advancedFundamentals[0].ExpensesAcquisitionMerger.Should().Be(0);
                advancedFundamentals[0].ExpensesCompensation.Should().Be(0);
                advancedFundamentals[0].ExpensesDepreciationAndAmortization.Should().Be(0);
                advancedFundamentals[0].ExpensesDerivative.Should().Be(0);
                advancedFundamentals[0].ExpensesDiscontinuedOperations.Should().Be(0);
                advancedFundamentals[0].ExpensesDiscontinuedOperationsReits.Should().Be(0);
                advancedFundamentals[0].ExpensesEnergy.Should().Be(0);
                advancedFundamentals[0].ExpensesForeignCurrency.Should().Be(0);
                advancedFundamentals[0].ExpensesInterest.Should().Be(0);
                advancedFundamentals[0].ExpensesInterestFinancials.Should().Be(0);
                advancedFundamentals[0].ExpensesInterestMinority.Should().Be(0);
                advancedFundamentals[0].ExpensesLegalRegulatoryInsurance.Should().Be(0);
                advancedFundamentals[0].ExpensesNonOperatingCompanyDefinedOther.Should().Be(0);
                advancedFundamentals[0].ExpensesNonOperatingOther.Should().Be(0);
                advancedFundamentals[0].ExpensesNonOperatingSubsidiaryUnconsolidated.Should().Be(0);
                advancedFundamentals[0].ExpensesNonRecurringOther.Should().Be(0);
                advancedFundamentals[0].ExpensesOperating.Should().Be(12483040873);
                advancedFundamentals[0].ExpensesOperatingOther.Should().Be(92870582);
                advancedFundamentals[0].ExpensesOperatingSubsidiaryUnconsolidated.Should().Be(0);
                advancedFundamentals[0].ExpensesOreo.Should().Be(0);
                advancedFundamentals[0].ExpensesOreoReits.Should().Be(0);
                advancedFundamentals[0].ExpensesOtherFinancing.Should().Be(-3231301125);
                advancedFundamentals[0].ExpensesRestructuring.Should().Be(-163555956);
                advancedFundamentals[0].ExpensesSga.Should().Be(5342674992);
                advancedFundamentals[0].ExpensesStockCompensation.Should().Be(0);
                advancedFundamentals[0].ExpensesWriteDown.Should().Be(0);
                advancedFundamentals[0].Ffo.Should().Be(0);
                advancedFundamentals[0].Figi.Should().Be("H40GB05PB9B0");
                advancedFundamentals[0].FilingDate.Should().Be(new DateTime(2000, 9, 19));
                advancedFundamentals[0].FilingType.Should().Be("01K");
                advancedFundamentals[0].FiscalQuarter.Should().Be(4);
                advancedFundamentals[0].FiscalYear.Should().Be(2000);
                advancedFundamentals[0].GoodwillAmortizationCashFlow.Should().Be(0);
                advancedFundamentals[0].GoodwillAmortizationIncomeStatement.Should().Be(0);
                advancedFundamentals[0].GoodwillAndIntangiblesNetOther.Should().Be(0);
                advancedFundamentals[0].GoodwillNet.Should().Be(0);
                advancedFundamentals[0].IncomeFromOperations.Should().Be(0);
                advancedFundamentals[0].IncomeNet.Should().Be(9876712662);
                advancedFundamentals[0].IncomeNetPerRevenue.Should().Be(0.428715526975316);
                advancedFundamentals[0].IncomeNetPerWabso.Should().Be(1.89);
                advancedFundamentals[0].IncomeNetPerWabsoSplitAdjusted.Should().Be(0.936366203594105);
                advancedFundamentals[0].IncomeNetPerWabsoSplitAdjustedYoyDeltaPercent.Should().Be(0.179956830359489);
                advancedFundamentals[0].IncomeNetPerWadso.Should().Be(1.7);
                advancedFundamentals[0].IncomeNetPerWadsoSplitAdjusted.Should().Be(0.86164289757498);
                advancedFundamentals[0].IncomeNetPerWadsoSplitAdjustedYoyDeltaPercent.Should().Be(0.198730830033077);
                advancedFundamentals[0].IncomeNetPreTax.Should().Be(14564361269);
                advancedFundamentals[0].IncomeNetYoyDelta.Should().Be(1643807769);
                advancedFundamentals[0].IncomeOperating.Should().Be(0);
                advancedFundamentals[0].IncomeOperatingDiscontinuedOperations.Should().Be(0);
                advancedFundamentals[0].IncomeOperatingOther.Should().Be(0);
                advancedFundamentals[0].IncomeOperatingSubsidiaryUnconsolidated.Should().Be(0);
                advancedFundamentals[0].IncomeOperatingSubsidiaryUnconsolidatedAfterTax.Should().Be(0);
                advancedFundamentals[0].IncomeTax.Should().Be(4997467773);
                advancedFundamentals[0].IncomeTaxCurrent.Should().Be(4967002243);
                advancedFundamentals[0].IncomeTaxDeferred.Should().Be(0);
                advancedFundamentals[0].IncomeTaxDiscontinuedOperations.Should().Be(0);
                advancedFundamentals[0].IncomeTaxOther.Should().Be(0);
                advancedFundamentals[0].IncomeTaxRate.Should().Be(0.356706924091196);
                advancedFundamentals[0].InterestMinority.Should().Be(0);
                advancedFundamentals[0].Inventory.Should().Be(0);
                advancedFundamentals[0].InventoryTurnover.Should().Be(0);
                advancedFundamentals[0].Liabilities.Should().Be(53339209718);
                advancedFundamentals[0].LiabilitiesCurrent.Should().Be(10132819168);
                advancedFundamentals[0].LiabilitiesNonCurrentAndInterestMinorityTotal.Should().Be(1072756067);
                advancedFundamentals[0].LiabilitiesNonCurrentDebt.Should().Be(0);
                advancedFundamentals[0].LiabilitiesNonCurrentDeferredCompensation.Should().Be(0);
                advancedFundamentals[0].LiabilitiesNonCurrentDeferredTax.Should().Be(1074295922);
                advancedFundamentals[0].LiabilitiesNonCurrentDiscontinuedOperations.Should().Be(0);
                advancedFundamentals[0].LiabilitiesNonCurrentLeasesOperating.Should().Be(0);
                advancedFundamentals[0].LiabilitiesNonCurrentLongTerm.Should().Be(0);
                advancedFundamentals[0].LiabilitiesNonCurrentOperatingDiscontinuedOperations.Should().Be(0);
                advancedFundamentals[0].LiabilitiesNonCurrentOther.Should().Be(0);
                advancedFundamentals[0].NibclDeferredCompensation.Should().Be(0);
                advancedFundamentals[0].NibclDeferredTax.Should().Be(0);
                advancedFundamentals[0].NibclDiscontinuedOperations.Should().Be(0);
                advancedFundamentals[0].NibclLeasesOperating.Should().Be(0);
                advancedFundamentals[0].NibclOther.Should().Be(3909498296);
                advancedFundamentals[0].NibclRestructuring.Should().Be(0);
                advancedFundamentals[0].NibclRevenueDeferred.Should().Be(5006790741);
                advancedFundamentals[0].NibclRevenueDeferredTurnover.Should().Be(4.80963089909927);
                advancedFundamentals[0].NibclSeparateAccounts.Should().Be(0);
                advancedFundamentals[0].Oci.Should().Be(1554676823);
                advancedFundamentals[0].PeriodEndDate.Should().Be(new DateTime(2000, 9, 28));
                advancedFundamentals[0].PpAndENet.Should().Be(1921740190);
                advancedFundamentals[0].PricePerEarnings.Should().Be(48.5904949202319);
                advancedFundamentals[0].PricePerEarningsPerRevenueYoyDeltaPercent.Should().Be(3.02529199458566);
                advancedFundamentals[0].ProfitGross.Should().Be(20917908239);
                advancedFundamentals[0].ProfitGrossPerRevenue.Should().Be(0.887953122168392);
                advancedFundamentals[0].ResearchAndDevelopmentExpense.Should().Be(3842833151);
                advancedFundamentals[0].Reserves.Should().Be(0);
                advancedFundamentals[0].ReservesInventory.Should().Be(0);
                advancedFundamentals[0].ReservesLifo.Should().Be(0);
                advancedFundamentals[0].ReservesLoanLoss.Should().Be(0);
                advancedFundamentals[0].Revenue.Should().Be(24069019401);
                advancedFundamentals[0].RevenueCostOther.Should().Be(3031939551);
                advancedFundamentals[0].RevenueIncomeInterest.Should().Be(0);
                advancedFundamentals[0].RevenueOther.Should().Be(23718394997);
                advancedFundamentals[0].RevenueSubsidiaryUnconsolidated.Should().Be(0);
                advancedFundamentals[0].SalesCost.Should().Be(3114198394);
                advancedFundamentals[0].SharesIssued.Should().Be(5461328561);
                advancedFundamentals[0].SharesOutstandingPeDateBs.Should().Be(0);
                advancedFundamentals[0].SharesTreasury.Should().Be(0);
                advancedFundamentals[0].StockCommon.Should().Be(0);
                advancedFundamentals[0].StockPreferred.Should().Be(0);
                advancedFundamentals[0].StockPreferredEquity.Should().Be(0);
                advancedFundamentals[0].StockPreferredMezzanine.Should().Be(0);
                advancedFundamentals[0].StockTreasury.Should().Be(0);
                advancedFundamentals[0].Symbol.Should().Be("MSFT");
                advancedFundamentals[0].Wabso.Should().Be(5330696285);
                advancedFundamentals[0].WabsoSplitAdjusted.Should().Be(10837405870);
                advancedFundamentals[0].Wadso.Should().Be(5622198972);
                advancedFundamentals[0].WadsoSplitAdjusted.Should().Be(11243710069);
                advancedFundamentals[0].Id.Should().Be("LSUAMDNFEANT");
                advancedFundamentals[0].Key.Should().Be("MTFS");
                advancedFundamentals[0].Subkey.Should().Be("mtt");
                advancedFundamentals[0].Updated.Should().Be(1668478218063);
            }
        }
    }
}
