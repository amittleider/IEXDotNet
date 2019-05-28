using System;

namespace IEXDotNet.IEXDataStructures
{
    public class IEXBalanceSheet
    {
        public DateTime ReportDate;
        public decimal? CurrentCash;
        public decimal? ShortTermInvestments;
        public decimal? Receivables;
        public decimal? Inventory;
        public decimal? OtherCurrentAssets;
        public decimal? CurrentAssets;
        public decimal? LongTermInvestments;
        public decimal? PropertyPlantEquipment;
        public decimal? Goodwill;
        public decimal? IntangibleAssets;
        public decimal? OtherAssets;
        public decimal? TotalAssets;
        public decimal? AccountsPayable;
        public decimal? LongTermDebt;
        public decimal? OtherLongTermDebt;
        public decimal? OtherCurrentLiabilities;
        public decimal? TotalCurrentLiabilities;
        public decimal? OtherLiabilities;
        public decimal? MinorityInterest;
        public decimal? TotalLiabilities;
        public decimal? CommonStock;
        public decimal? RetainedEarnings;
        public decimal? TreasuryStock;
        public decimal? CapitalSurplus;
        public decimal? ShareholderEquity;
        public decimal? NetTangibleAssets;
    }
}