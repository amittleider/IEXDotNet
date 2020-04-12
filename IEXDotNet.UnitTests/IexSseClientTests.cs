using FluentAssertions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace IEXDotNet.UnitTests
{
    public class IexSseClientTests
    {
        [Fact]
        public async Task CryptoSubscription_Should_ThrowEvents()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IexSseClient client = new IexSseClient(IEXBaseUrl.SandboxSseUrl, token);

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            client.CryptoQuoteEvent += (sender, e) => // Set the client to cancel the event when a message is received
            {
                e.Symbol.Should().Be("BTCUSDT");
                tokenSource.Cancel();
            };

            await client.SubscribeToCryptoQuote("BTCUSDT", tokenSource.Token);
        }

        [Fact]
        public async Task NewsSubscription_Should_ThrowEvents()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IexSseClient client = new IexSseClient(IEXBaseUrl.SandboxSseUrl, token);

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            client.NewsEvent += (sender, e) => // Set the client to cancel the event when a message is received
            {
                e.Should().NotBeNull();
                tokenSource.Cancel();
            };

            await client.SubscribeToNewsStream("spy", tokenSource.Token);
        }


        [Fact]
        public async Task NewsSubscription_Should_Subscribe_WithTwoSymbols()
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();
            string token = config["TOKEN"];
            IexSseClient client = new IexSseClient(IEXBaseUrl.SandboxSseUrl, token);

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            client.NewsEvent += (sender, e) => // Set the client to cancel the event when a message is received
            {
                e.Should().NotBeNull();
                tokenSource.Cancel();
            };

            await client.SubscribeToNewsStream("spy,msft,aapl,tsla", tokenSource.Token);
        }
    }
}
