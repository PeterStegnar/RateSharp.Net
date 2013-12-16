//  ***********************************************************************
//   Solution	: RateSharp.Net
//   Project	: RateSharp.Net
//   Author		: F Aydin
//   Created	: 00:26, 16:12:2013
//    
//   Last Modified By	: F Aydin
//   Last Modified On 	: 00:51, 16:12:2013
//  ***********************************************************************

using System;

using Newtonsoft.Json;

namespace RateSharp.Net.Converter
{
    internal class DateTimeConverter : JsonConverter
    {
        #region Read / Write Json

        /// <summary>
        ///     Reads the JSON representation of the object
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from</param>
        /// <param name="objectType">Type of the object</param>
        /// <param name="existingValue">The existing value of object being read</param>
        /// <param name="serializer">The calling serializer</param>
        /// <returns>The object value</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var timeStamp = ((long) reader.Value);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return epoch.AddSeconds(timeStamp);
        }

        /// <summary>
        ///     Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Can Convert/Write

        /// <summary>
        ///     Gets a value indicating whether this <see cref="T:Newtonsoft.Json.JsonConverter" /> can write JSON.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this <see cref="T:Newtonsoft.Json.JsonConverter" /> can write JSON; otherwise, <c>false</c>.
        /// </value>
        public override bool CanWrite
        {
            get { return false; }
        }

        /// <summary>
        ///     Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        ///     <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (DateTime);
        }

        #endregion
    }
}
