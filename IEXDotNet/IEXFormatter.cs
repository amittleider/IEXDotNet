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

        public IEXIncomeStatementList FormatIncomeStatement(string incomeStatementJson)
        {
            IEXIncomeStatementList incomeStatementList = JsonConvert.DeserializeObject<IEXIncomeStatementList>(incomeStatementJson);

            return incomeStatementList;
        }

        public IEXCashFlowStatementList FormatCashFlowStatement(string cashFlowStatementJson)
        {
            IEXCashFlowStatementList cashFlowStatementList = JsonConvert.DeserializeObject<IEXCashFlowStatementList>(cashFlowStatementJson);

            return cashFlowStatementList;
        }

        public List<string> FormatPeers(string peersJson)
        {
            List<string> cashFlowStatementList = JsonConvert.DeserializeObject<List<string>>(peersJson);

            return cashFlowStatementList;
        }
    }
}
