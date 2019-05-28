using System;

namespace IEXDotNet.IEXDataStructures
{
    public class IEXCashFlowStatement
    {
        public DateTime ReportDate;
        public decimal? NetIncome;
        public decimal? Depreciation;
        public decimal? ChangesInReceivables;
        public decimal? ChangesInInventories;
        public decimal? CashChange;
        public decimal? CashFlow;
        public decimal? CapitalExpenditures;
        public decimal? Investments;
        public decimal? InvestingActivityOther;
        public decimal? TotalInvestingCashFlows;
        public decimal? DividendsPaid;
        public decimal? NetBorrowings;
        public decimal? OtherFinancialCashFlows;
        public decimal? CashFlowFinancing;
        public decimal? ExchangeRateEffect;
    }
}