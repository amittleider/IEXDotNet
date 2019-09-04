using IEXDotNet.IEXDataStructures.Converters;
using Newtonsoft.Json;
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

        [JsonConverter(typeof(MinDateTimeConverter))]
        public DateTime LastUpdated
        {
            get;
            set;
        }
    }
}
