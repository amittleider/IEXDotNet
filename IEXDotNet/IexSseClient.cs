using IEXDotNet.IEXDataStructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IEXDotNet
{
    public class IexSseClient
    {
        private readonly string baseUrl;
        private readonly string token;
        private readonly IEXFormatter iexFormatter;
        private readonly HttpClient client;

        public event EventHandler<IexCryptoQuote> CryptoQuoteEvent = null;
        public event EventHandler<IexNews> NewsEvent = null;

        public IexSseClient(string baseUrl, string token)
        {
            this.baseUrl = baseUrl;
            this.token = token;
            this.iexFormatter = new IEXFormatter();
            this.client = new HttpClient();
        }

        public async Task SubscribeToCryptoQuote(string symbols, CancellationToken cancelationToken)
        {
            var routeUrl = $"cryptoQuotes";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?symbols={symbols}&token={token}");

            var config = LaunchDarkly.EventSource.Configuration.Builder(requestUrl).Build();
            var eventSource = new LaunchDarkly.EventSource.EventSource(config);

            eventSource.MessageReceived += (s, e) =>
            {
                var data = e.Message.Data;
                var cryptoQuotes = this.iexFormatter.FormatCryptoQuoteLine(data);
                foreach (var cryptoQuote in cryptoQuotes)
                {
                    this.CryptoQuoteEvent?.Invoke(this, cryptoQuote);
                }

                if (cancelationToken.IsCancellationRequested)
                {
                    eventSource.Close();
                }
            };

            await eventSource.StartAsync();
        }

        public async Task SubscribeToNewsStream(string symbols, CancellationToken cancelationToken)
        {
            var routeUrl = $"news-stream";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?symbols={symbols}&token={token}");

            var config = LaunchDarkly.EventSource.Configuration.Builder(requestUrl).Build();
            var eventSource = new LaunchDarkly.EventSource.EventSource(config);

            eventSource.MessageReceived += (s, e) =>
            {
                var data = e.Message.Data;
                var newsEvents = this.iexFormatter.FormatNewsLine(data);
                foreach (var newsEvent in newsEvents)
                {
                    this.NewsEvent?.Invoke(this, newsEvent);
                }

                if (cancelationToken.IsCancellationRequested)
                {
                    eventSource.Close();
                }
            };

            await eventSource.StartAsync();
        }
    }
}
