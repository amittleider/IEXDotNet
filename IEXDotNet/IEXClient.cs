using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEXDotNet
{
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
        public virtual async Task<string> GetIEXSymbols()
        {
            var routeUrl = $"ref-data/iex/symbols";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}");
            var stringTask = client.GetStringAsync(requestUrl);

            return await stringTask;
        }

        /// <summary>
        /// GET /ref-data/symbols
        /// </summary>
        /// <returns>The raw string result of the request.</returns>
        public virtual async Task<string> GetSymbols()
        {
            var routeUrl = $"ref-data/symbols";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}");
            var stringTask = client.GetStringAsync(requestUrl);

            return await stringTask;
        }

        /// <summary>
        /// GET /stock/{symbol}/balance-sheet/{last}/{field}
        /// </summary>
        /// <returns>The raw string result of the request.</returns>
        public virtual async Task<string> GetBalanceSheet(string symbol, int last, string frequency)
        {
            var routeUrl = $"stock/{symbol}/balance-sheet/{last}";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}&period={frequency}");
            var stringTask = client.GetStringAsync(requestUrl);

            return await stringTask;
        }

        /// <summary>
        /// GET /stock/{symbol}/income/{last}/{field}
        /// </summary>
        /// <returns>The raw string result of the request.</returns>
        public virtual async Task<string> GetIncomeStatement(string symbol, int last, string frequency)
        {
            var routeUrl = $"stock/{symbol}/income/{last}";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}&period={frequency}");
            var stringTask = client.GetStringAsync(requestUrl);

            return await stringTask;
        }

        /// <summary>
        /// GET /stock/{symbol}/cash-flow/{last}/{field}
        /// </summary>
        /// <returns>The raw string result of the request.</returns>
        public virtual async Task<string> GetCashFlowStatement(string symbol, int last, string frequency)
        {
            var routeUrl = $"stock/{symbol}/cash-flow/{last}";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}&period={frequency}");
            var stringTask = client.GetStringAsync(requestUrl);

            return await stringTask;
        }

        /// <summary>
        /// GET /stock/{symbol}/upcoming-earnings
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>The raw string result of the request.</returns>
        public virtual async Task<string> GetUpcomingEarnings(string symbol)
        {
            var routeUrl = $"stock/{symbol}/upcoming-earnings";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}");
            var stringTask = client.GetStringAsync(requestUrl);

            return await stringTask;
        }

        /// <summary>
        /// GET /stock/{symbol}/peers
        /// This API is known to return weird results and there is an open bug here: https://github.com/iexg/IEX-API/issues/616
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>The raw string result of the request.</returns>
        public virtual async Task<string> GetPeers(string symbol)
        {
            var routeUrl = $"stock/{symbol}/peers";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}");
            var responseString = await client.GetStringAsync(requestUrl);

            return responseString;
        }

        /// <summary>
        /// GET /stock/{symbol}/short-interest
        /// This API is still in Dev and can throw exceptions
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public virtual async Task<string> GetShortInterest(string symbol)
        {
            var routeUrl = $"stock/{symbol}/short-interest";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}");

            string responseString = string.Empty;

            responseString = await client.GetStringAsync(requestUrl);

            return responseString;
        }

        /// <summary>
        /// GET /stock/{symbol}/chart/{range}/{date}
        /// https://iexcloud.io/docs/api/#historical-prices
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <returns></returns>
        public virtual async Task<string> GetHistoricalPrices(string symbol, string range, bool chartCloseOnly = false)
        {
            string routeUrl = $"stock/{symbol}/chart/{range}";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?chartCloseOnly={chartCloseOnly}&token={token}");
            var responseString = await client.GetStringAsync(requestUrl);

            return responseString;
        }

        /// <summary>
        /// GET /account/usage/{type}
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual async Task<string> GetAccountUsage()
        {
            string routeUrl = $"account/usage";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}");
            var responseString = await client.GetStringAsync(requestUrl);

            return responseString;
        }

        /// <summary>
        /// GET /stock/{symbol}/dividends/{range}
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual async Task<string> GetDividends(string symbol, string range)
        {
            string routeUrl = $"stock/{symbol}/dividends/{range}";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}");
            var responseString = await client.GetStringAsync(requestUrl);

            return responseString;
        }

        /// <summary>
        /// To find out the most recent available 10-K/10-Qs
        /// GET /data-points/{symbol}
        /// </summary>
        public virtual async Task<string> GetDataPoints(string symbol)
        {
            string routeUrl = $"data-points/{symbol}";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}");
            var responseString = await client.GetStringAsync(requestUrl);

            return responseString;
        }

        /// <summary>
        /// To find out the most recent available 10-K/10-Qs
        /// GET /data-points/{symbol}/{VARIABLE}
        /// </summary>
        public virtual async Task<string> GetDataPoint(string symbol, IexDataPointVariable iexDataPointVariable)
        {
            string dataPointVariable = iexDataPointVariable.GetDescription();
            return await GetDataPoint(symbol, dataPointVariable);
        }

        /// <summary>
        /// To find out the most recent available 10-K/10-Qs
        /// GET /data-points/{symbol}/{VARIABLE}
        /// </summary>
        public virtual async Task<string> GetDataPoint(string symbol, string iexDataPointVariable)
        {
            string routeUrl = $"data-points/{symbol}/{iexDataPointVariable}";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}");
            var responseString = await client.GetStringAsync(requestUrl);

            return responseString;
        }


        public virtual async Task<string> GetTimeSeries(string key, string symbol)
        {
            string routeUrl = $"time-series/{key}/{symbol}";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}");
            var responseString = await client.GetStringAsync(requestUrl);

            return responseString;
        }

        public virtual async Task<string> GetKeyStats(string symbol)
        {
            string routeUrl = $"stock/{symbol}/stats";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}");
            var responseString = await client.GetStringAsync(requestUrl);

            return responseString;
        }

        /// <summary>
        /// // GET /stock/{symbol}/company
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public virtual async Task<string> GetCompany(string symbol)
        {
            string routeUrl = $"stock/{symbol}/company";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}");
            var responseString = await client.GetStringAsync(requestUrl);

            return responseString;
        }

        public virtual async Task<string> GetTopsLast()
        {
            string routeUrl = $"tops/last";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}?token={token}");
            var responseString = await client.GetStringAsync(requestUrl);

            return responseString;
        }

        public virtual async Task<string> GetTopsLast(string symbol)
        {
            string routeUrl = $"tops/last?symbols={symbol}";
            var requestUrl = new Uri($"{baseUrl}/{routeUrl}&token={token}");
            var responseString = await client.GetStringAsync(requestUrl);

            return responseString;
        }
    }
}
