using System;
using Newtonsoft.Json;
using Utilities.Extension;

namespace RateSharp.Net.Models.Converter
{
    public class DateTimeConverter : JsonConverter
    {
        public override bool CanWrite
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var timeStamp = ((long) reader.Value);

            return timeStamp.ConvertEpochToUtcDateTime();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (DateTime);
        }
    }
}