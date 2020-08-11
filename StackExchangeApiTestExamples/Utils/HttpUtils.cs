using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace StackExchangeApiTestExamples.Utils
{
    /// <summary>
    ///     Utilities to make it easier to send/recieve requests in our tests
    /// </summary>
    public class HttpUtils
    {
        /// <summary>
        ///     Sends GET request to specified url
        /// </summary>
        /// <typeparam name="T">object type to return</typeparam>
        /// <param name="baseAddress">the base address for our request</param>
        /// <param name="requestUri">the remainder of the url</param>
        /// <returns>object of type T</returns>
        public static T SendGetRequest<T>(string baseAddress, string requestUri)
        {
            //Set the automatic decompression of the response
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Get the response
                HttpResponseMessage response = client.GetAsync(requestUri).Result;
                //Deserialize the string to the object type
                return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
