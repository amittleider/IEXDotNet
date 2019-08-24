using FluentAssertions;
using Microsoft.Extensions.Configuration;
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

        [Fact(Skip = "Must have at least 'Grow' access for Upcoming Earnings calls. The CI does not.")]
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
            string result = await client.GetHistoricalPrices("msft", "3m");
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
    }
}
