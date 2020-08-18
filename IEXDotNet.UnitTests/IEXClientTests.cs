using FluentAssertions;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace IEXDotNet.UnitTests
{
    public class IEXClientTests
    {
        [Fact]
        public async Task GetIEXSymbols_Should_FetchResults()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetIEXSymbols();
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetSymbols_Should_FetchResults()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetSymbols();
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetBalanceSheet_Should_FetchResults()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetBalanceSheet("AAPL", 4, "quarter");
            result.Should().NotBeNullOrEmpty();

            result = await client.GetBalanceSheet("AAPL", 4, "annual");
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetIncomeStatement_Should_FetchResults()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetIncomeStatement("AAPL", 4, "quarter");
            result.Should().NotBeNullOrEmpty();

            result = await client.GetIncomeStatement("AAPL", 4, "annual");
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetCashFlowStatement_Should_FetchResults()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetCashFlowStatement("AAPL", 4, "quarter");
            result.Should().NotBeNullOrEmpty();

            result = await client.GetCashFlowStatement("AAPL", 4, "annual");
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetPeers_Should_FetchResult()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetPeers("NKE");
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetUpcomingEarnings_Should_FetchResults()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetUpcomingEarnings("AAPL");
            result.Should().NotBeNullOrEmpty();
        }

        [Fact(Skip = "Still in dev, can throw exceptions")]
        public async Task GetShortInterest_Should_FetchResults()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetShortInterest("msft");
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetHistoricalPrices_Should_FetchResults()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetHistoricalPrices("msft", "5d");
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetHistoricalPrices_WithChartCloseOnly_Should_FetchResults()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetHistoricalPrices("msft", "5d", chartCloseOnly: true);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetAccountUsage_Should_FetchResults()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetAccountUsage();
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetDividends_Should_FetchResults()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetDividends("MSFT", "1y");
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetDataPoints_Should_FetchResults()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetDataPoints("MSFT");
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetDataPoint_Should_FetchResults()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetDataPoint("MSFT", IexDataPointVariable.LATEST_FINANCIAL_REPORT_DATE);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact(Skip = "This test case fails in the sandbox environment, but passes in prod.")]
        public async Task LastReportDate_Should_BeTheSameAs_TheDataPointForTheLastReportDate()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);

            IEXFormatter formatter = new IEXFormatter();

            // Get the last updated data point
            string dataPointResult = await client.GetDataPoint("MSFT", IexDataPointVariable.LATEST_FINANCIAL_REPORT_DATE);
            DateTime lastUpdated = formatter.FormatDataPoint(dataPointResult);

            // Get the actual point that was supposed to be updated
            var balanceSheetString = await client.GetBalanceSheet("MSFT", 1, "quarter");
            var balanceSheet = formatter.FormatBalanceSheet(balanceSheetString);

            // Ensure they are the same time
            balanceSheet.BalanceSheet[0].ReportDate.Should().Be(lastUpdated);
        }

        [Fact]
        public async Task GetTimeSeries_Should_FetchResults()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetTimeSeries("REPORTED_FINANCIALS", "MSFT");
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetKeyStats_Should_FetchResults()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetKeyStats("MSFT");
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetCompany_Should_FetchResults()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetCompany("MSFT");
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Should_GetTopsLast_ForSingleCompany()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetTopsLast("MSFT");
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Should_GetTopsLast_ForEverything()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IEXClient client = new IEXClient(IEXBaseUrl.SandboxUrl, token);
            string result = await client.GetTopsLast();
            result.Should().NotBeNullOrEmpty();
        }
    }
}
