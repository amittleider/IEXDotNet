using System;

namespace IEXDotNet.IEXDataStructures
{
    public class IexDataPoint
    {
        public string Key
        {
            get;
            set;

        }

        public int Weight
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public DateTime LastUpdated
        {
            get;
            set;
        }
    }
}
