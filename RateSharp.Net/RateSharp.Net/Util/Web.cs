//  ***********************************************************************
//   Solution	: RateSharp.Net
//   Project	: RateSharp.Net
//   Author		: F Aydin
//   Created	: 23:08, 15:12:2013
//    
//   Last Modified By	: F Aydin
//   Last Modified On 	: 00:53, 16:12:2013
//  ***********************************************************************

using System;
using System.IO;
using System.Net;

namespace RateSharp.Net.Util
{
    internal class Web
    {
        /// <summary>
        ///     Creates a WebRequest to the API.
        /// </summary>
        /// <param name="url">URL of the API</param>
        /// <returns>Json response</returns>
        internal static string Get(string url)
        {
            try
            {
                string content;
                var request = (HttpWebRequest) WebRequest.Create(url);
                request.UserAgent = "RatesSharp";
                request.Accept = "*/*";
                request.Headers.Add("Accept-Language: en-US,en;q=0.5");

                using (var response = (HttpWebResponse) request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        if (stream == null) return "Error: HttpWebResponse is null";
                        using (var streamReader = new StreamReader(stream)) content = streamReader.ReadToEnd();
                    }
                }

                return content;
            }
            catch (Exception exception)
            {
                return "Error: " + exception.Message;
            }
        }
    }
}
