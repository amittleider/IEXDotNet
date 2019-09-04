using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace IEXDotNet.IEXDataStructures.Converters
{
    public class MinDateTimeConverter : DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return DateTime.MinValue;
            }

            if (reader.ValueType == typeof(string) && (string)reader.Value == string.Empty)
            {
                return DateTime.MinValue;
            }

            return ((DateTime)reader.Value).ToUniversalTime();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DateTime dateTimeValue = (DateTime)value;
            if (dateTimeValue == DateTime.MinValue)
            {
                writer.WriteNull();
                return;
            }

            writer.WriteValue(value);
        }
    }
}
