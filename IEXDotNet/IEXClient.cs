using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEXDotNet
{
    /// <summary>
    /// pip install git+https://github.com/QuantConnect/pythonnet.git
    /// </summary>
    public class IEXClient
    {
        private readonly string baseUrl;
        private readonly string token;
        private readonly HttpClient client;

        public IEXClient(string baseUrl, string token)
        {
            this.baseUrl = baseUrl;
            this.token = token;
            this.client = new HttpClient();
        }

        /// <summary>
        /// GET /ref-data/iex/symbols
        /// </summary>
        /// <returns>The raw string result of the request.</returns>
        public async Task<string> GetIEXSymbols()
        {
            var routeUrl = $"ref-data/iex/symbols";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}");
            var stringTask = client.GetStringAsync(requestUrl);

            return await stringTask;
        }

        /// <summary>
        /// GET /stock/{symbol}/balance-sheet/{last}/{field}
        /// </summary>
        /// <returns>The raw string result of the request.</returns>
        public async Task<string> GetBalanceSheet(string symbol, int last)
        {
            var routeUrl = $"stock/{symbol}/balance-sheet/{last}";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}");
            var stringTask = client.GetStringAsync(requestUrl);

            return await stringTask;
        }

        /// <summary>
        /// GET /stock/{symbol}/income/{last}/{field}
        /// </summary>
        /// <returns>The raw string result of the request.</returns>
        public async Task<string> GetIncomeStatement(string symbol, int last)
        {
            var routeUrl = $"stock/{symbol}/income/{last}";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}");
            var stringTask = client.GetStringAsync(requestUrl);

            return await stringTask;
        }

        /// <summary>
        /// GET /stock/{symbol}/cash-flow/{last}/{field}
        /// </summary>
        /// <returns>The raw string result of the request.</returns>
        public async Task<string> GetCashFlowStatement(string symbol, int last)
        {
            var routeUrl = $"stock/{symbol}/cash-flow/{last}";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}");
            var stringTask = client.GetStringAsync(requestUrl);

            return await stringTask;
        }

        /// <summary>
        /// GET /stock/{symbol}/upcoming-earnings
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>The raw string result of th request.</returns>
        public async Task<string> GetUpcomingEarnings(string symbol)
        {
            var routeUrl = $"stock/{symbol}/upcoming-earnings";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}");
            var stringTask = client.GetStringAsync(requestUrl);

            return await stringTask;
        }
    }
}
