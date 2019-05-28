using System.Collections.Generic;

namespace IEXDotNet.IEXDataStructures
{
    public class IEXBalanceSheetList
    {
        public string Symbol
        {
            get;
            set;
        }

        public List<IEXBalanceSheet> BalanceSheet
        {
            get;
            set;
        }
    }
}