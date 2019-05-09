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
            string result = await client.GetBalanceSheet("AAPL", 4);
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
            string result = await client.GetIncomeStatement("AAPL", 4);
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
            string result = await client.GetCashFlowStatement("AAPL", 4);
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
    }
}
