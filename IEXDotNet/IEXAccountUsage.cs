namespace IEXDotNet
{
    public class IEXAccountUsage
    {
        public class IEXAccountUsageMessages
        {
            public int MonthlyUsage
            {
                get;
                set;
            }
        }

        public IEXAccountUsageMessages Messages
        {
            get;
            set;
        }

        ////      {
        ////"messages": {
        ////  "dailyUsage": {
        ////    "20190803": "127422"
        ////  },
        ////  "monthlyUsage": 128054,
        ////  "monthlyPayAsYouGo": 0,
        ////  "tokenUsage": {
        ////    "Tsk_2761d3806c9c4bd6aa1ee70fc981a430": "126230"
        ////  },
        ////  "keyUsage": {
        ////    "CASH_FLOW": "24303",
        ////    "STOCK_PEERS": "1534",
        ////    "REF_DATA_IEX_SYMBOLS": "0",
        ////    "INCOME": "25056",
        ////    "BALANCE_SHEET": "73026",
        ////    "HISTORICAL_PRICES": "2587"
        ////  }
        ////},
        ////"rules": [
    }
}