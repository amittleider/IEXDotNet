﻿namespace IEXDotNet.IEXDataStructures
{
    public class IexNews
    {
        ////        {
        ////    "datetime": 1545215400000,
        ////    "headline": "Voice Search Technology Creates A New Paradigm For Marketers",
        ////    "source": "Benzinga",
        ////    "url": "https://cloud.iexapis.com/stable/news/article/8348646549980454",
        ////    "summary": "<p>Voice search is likely to grow by leap and bounds, with technological advancements leading to better adoption and fueling the growth cycle, according to Lindsay Boyajian, <a href=\"http://loupventures.com/how-the-future-of-voice-search-affects-marketers-today/\">a guest contributor at Loup Ventu...",
        ////    "related": "AAPL,AMZN,GOOG,GOOGL,MSFT",
        ////    "image": "https://cloud.iexapis.com/stable/news/image/7594023985414148",
        ////    "lang": "en",
        ////    "hasPaywall": true
        ////}
        ///
        public long Datetime;
        public string Headline;
        public string Source;
        public string Url;
        public string Summary;
        public string Related;
        public string Image;
        public string Lang;
        public bool HasPaywall;

        public override string ToString()
        {
            return $"{this.Headline}: {this.Url}";
        }
    }
}
