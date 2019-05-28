using System;

namespace IEXDotNet.IEXDataStructures
{
    public class IEXIncomeStatement
    {
        public DateTime ReportDate;
        public decimal? TotalRevenue;
        public decimal? CostOfRevenue;
        public decimal? GrossProfit;
        public decimal? ResearchAndDevelopment;
        public decimal? SellingGeneralAndAdmin;
        public decimal? OperatingExpense;
        public decimal? OperatingIncome;
        public decimal? OtherIncomeExpenseNet;
        public decimal? EBIT;
        public decimal? InterestIncome;
        public decimal? PretaxIncome;
        public decimal? IncomeTax;
        public decimal? MinorityInterest;
        public decimal? NetIncome;
        public decimal? NetIncomeBasic;
    }
}