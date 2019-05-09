using IEXDotNet.IEXDataStructures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEXDotNet
{
    public class IEXFormatter
    {
        public List<IEXSymbol> FormatIEXSymbols(string iexSymbols)
        {
            List<IEXSymbol> symbolsList = JsonConvert.DeserializeObject<List<IEXSymbol>>(iexSymbols);

            return symbolsList;
        }

        public IEXBalanceSheetList FormatBalanceSheet(string balanceSheet)
        {
            IEXBalanceSheetList balanceSheetList = JsonConvert.DeserializeObject<IEXBalanceSheetList>(balanceSheet);

            return balanceSheetList;
        }
    }
}
