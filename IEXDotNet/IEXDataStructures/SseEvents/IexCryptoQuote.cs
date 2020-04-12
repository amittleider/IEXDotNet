namespace IEXDotNet.IEXDataStructures
{
    public class IexCryptoQuote
    {
        ////        data: [
        ////  {
        ////    "symbol": "BTCUSDT",
        ////    "primaryExchange": "0",
        ////    "sector": "eroypccctrryun",
        ////    "calculationPrice": "realtime",
        ////    "latestPrice": "6891.07",
        ////    "latestSource": "Real time price",
        ////    "latestUpdate": 1663265025835,
        ////    "latestVolume": null,
        ////    "bidPrice": "7008.44",
        ////    "bidSize": "0.007707",
        ////    "askPrice": "7042.77",
        ////    "askSize": "0.003781",
        ////    "high": null,
        ////    "low": null,
        ////    "previousClose": null
        ////  }
        ////]
        ///
        public string Symbol;
        public string PrimaryExchange;
        public string Sector;
        public string CalculationPrice;
        public double LatestPrice;
        public string LatestSource;
        public long LatestUpdate;
        public double? LatestVolume;
        public double BidPrice;
        public double BidSize;
        public double AskPrice;
        public double AskSize;
        public double? High;
        public double? Low;
        public double? PreviousClose;

        public override string ToString() =>
                   $"{Symbol},{LatestUpdate},{LatestPrice},{LatestVolume}";
    }
}