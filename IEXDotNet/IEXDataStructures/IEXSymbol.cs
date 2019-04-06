using System;

namespace IEXDotNet.IEXDataStructures
{
    public class IEXSymbol
    {
        public string Symbol
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get;
            set;
        }
    }
}