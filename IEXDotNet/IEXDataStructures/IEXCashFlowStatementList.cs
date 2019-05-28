using System.Collections.Generic;

namespace IEXDotNet.IEXDataStructures
{
    public class IEXCashFlowStatementList
    {
        public string Symbol
        {
            get;
            set;
        }

        public List<IEXCashFlowStatement> CashFlow
        {
            get;
            set;
        }
    }
}
