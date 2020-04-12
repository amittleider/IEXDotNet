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
            using (var stream = await client.GetStreamAsync(requestUrl))
            {
                using (var reader = new StreamReader(stream))
                {

                    while (!reader.EndOfStream)
                    {
                        var line = await reader.ReadLineAsync();
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            IexCryptoQuote cryptoQuote = this.iexFormatter.FormatCryptoQuoteLine(line);
                            this.CryptoQuoteEvent?.Invoke(this, cryptoQuote);
                        }

                        if (cancelationToken.IsCancellationRequested)
                        {
                            break;
                        }
                    }
                }
            }
        }

        public async Task SubscribeToNewsStream(string symbols, CancellationToken cancelationToken)
        {
            var routeUrl = $"news-stream";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?symbols={symbols}&token={token}");
            using (var stream = await client.GetStreamAsync(requestUrl))
            {
                using (var reader = new StreamReader(stream))
                {

                    while (!reader.EndOfStream)
                    {
                        var line = await reader.ReadLineAsync();
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            IexNews newsLine = this.iexFormatter.FormatNewsLine(line);
                            this.NewsEvent?.Invoke(this, newsLine);
                        }

                        if (cancelationToken.IsCancellationRequested)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
