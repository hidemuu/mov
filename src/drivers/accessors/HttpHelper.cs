using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Accessors
{
    public class HttpHelper
    {
        /// <summary>           
        /// The Base URL for the API.
        /// /// </summary>
        private readonly string _baseUrl;

        public HttpHelper(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        /// <summary>
        /// Makes an HTTP GET request to the given controller and returns the deserialized response content.
        /// </summary>
        public async Task<TResult> GetAsync<TResult>(string controller)
        {
            using (var client = BaseClient())
            {
                var response = await client.GetAsync(controller);
                string json = await response.Content.ReadAsStringAsync();
                TResult obj = JsonConvert.DeserializeObject<TResult>(json);
                return obj;
            }
        }

        /// <summary>
        /// Makes an HTTP POST request to the given controller with the given object as the body.
        /// Returns the deserialized response content.
        /// </summary>
        public async Task<TResult> PostAsync<TRequest, TResult>(string controller, TRequest body)
        {
            using (var client = BaseClient())
            {
                var response = await client.PostAsync(controller, new JsonStringContent(body));
                string json = await response.Content.ReadAsStringAsync();
                TResult obj = JsonConvert.DeserializeObject<TResult>(json);
                return obj;
            }
        }

        /// <summary>
        /// Makes an HTTP DELETE request to the given controller and includes all the given
        /// object's properties as URL parameters. Returns the deserialized response content.
        /// </summary>
        public async Task DeleteAsync(string controller, Guid objectId)
        {
            using (var client = BaseClient())
            {
                await client.DeleteAsync($"{controller}/{objectId}");
            }
        }

        /// <summary>
        /// Constructs the base HTTP client, including correct authorization and API version headers.
        /// </summary>
        private HttpClient BaseClient() => new HttpClient { BaseAddress = new Uri(_baseUrl) };

        /// <summary>
        /// Helper class for formatting <see cref="StringContent"/> as UTF8 application/json. 
        /// </summary>
        private class JsonStringContent : StringContent
        {
            /// <summary>
            /// Creates <see cref="StringContent"/> formatted as UTF8 application/json.
            /// </summary>
            public JsonStringContent(object obj)
                : base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
            { }
        }
    }
}
