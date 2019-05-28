using System.Collections.Generic;

namespace IEXDotNet.IEXDataStructures
{
    public class IEXIncomeStatementList
    {
        public string Symbol
        {
            get;
            set;
        }

        public List<IEXIncomeStatement> Income
        {
            get;
            set;
        }
    }
}