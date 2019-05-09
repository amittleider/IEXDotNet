using FluentAssertions;
using IEXDotNet.IEXDataStructures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace IEXDotNet.UnitTests
{
    public class IEXFormatterTests
    {
        [Fact]
        public void Should_Format_IEXSymbols()
        {
            using (StreamReader reader = new StreamReader("AllIEXSymbols.txt"))
            {
                string symbols = reader.ReadToEnd();

                IEXFormatter formatter = new IEXFormatter();
                List<IEXSymbol> symbolsList = formatter.FormatIEXSymbols(symbols);

                symbolsList[0].Symbol.Should().Be("A");
                symbolsList[0].Date.Should().Be(new DateTime(2019, 4, 5));
                symbolsList[0].IsEnabled.Should().Be(true);
                symbolsList.Count.Should().Be(8737);
            }
        }

        [Fact]
        public void Should_Format_BalanceSheet()
        {
            using (StreamReader reader = new StreamReader("BalanceSheet.txt"))
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
    }
}
