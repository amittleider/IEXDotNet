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
        public void Should_Format_IEXSymbolsCall()
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
    }
}
