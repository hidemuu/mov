﻿using Mov.Core.Accessors.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Accessors.Serializer
{
    public class HttpSerializer
    {
        #region property

        public PathValue Endpoint { get; }

        public EncodingValue Encoding { get; }

        #endregion property

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="endpoint"></param>
        public HttpSerializer(PathValue endpoint, EncodingValue encoding)
        {
            Endpoint = endpoint;
            Encoding = encoding;
        }

        #endregion constructor

        #region method

        public TResponse Deserialize<TRequest, TResponse>(string url)
        {
            using (var client = BaseClient())
            {
                var responseTask = client.GetAsync(url);
                Task.WhenAll(responseTask);
                var jsonTask = responseTask.Result.Content.ReadAsStringAsync();
                Task.WhenAll(jsonTask);
                TResponse obj = JsonConvert.DeserializeObject<TResponse>(jsonTask.Result);
                return obj;
            }
        }

        public TResponse Serialize<TRequest, TResponse>(string url, TRequest body)
        {
            using (var client = BaseClient())
            {
                var responseTask = client.PostAsync(url, new JsonStringContent(body, Encoding.Value));
                Task.WhenAll(responseTask);
                return default;
            }
        }

        /// <summary>
        /// Makes an HTTP GET request to the given controller and returns the deserialized response content.
        /// </summary>
        public async Task<TResponse> GetAsync<TResponse>(string url)
        {
            using (var client = BaseClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                TResponse obj = JsonConvert.DeserializeObject<TResponse>(json);
                return obj;
            }
        }

        /// <summary>
        /// Makes an HTTP POST request to the given controller with the given object as the body.
        /// Returns the deserialized response content.
        /// </summary>
        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest body)
        {
            using (var client = BaseClient())
            {
                var response = await client.PostAsync(url, new JsonStringContent(body, Encoding.Value));
                string json = await response.Content.ReadAsStringAsync();
                TResponse obj = JsonConvert.DeserializeObject<TResponse>(json);
                return obj;
            }
        }

        /// <summary>
        /// Makes an HTTP DELETE request to the given controller and includes all the given
        /// object's properties as URL parameters. Returns the deserialized response content.
        /// </summary>
        public async Task DeleteAsync(string url, string key)
        {
            using (var client = BaseClient())
            {
                var response = await client.DeleteAsync($"{url}/{key}");
            }
        }

        #endregion method

        #region private method

        /// <summary>
        /// Constructs the base HTTP client, including correct authorization and API version headers.
        /// </summary>
        private HttpClient BaseClient() => new HttpClient { BaseAddress = new Uri(Endpoint.Value) };

        /// <summary>
        /// Helper class for formatting <see cref="StringContent"/> as UTF8 application/json.
        /// </summary>
        private class JsonStringContent : StringContent
        {
            /// <summary>
            /// Creates <see cref="StringContent"/> formatted as UTF8 application/json.
            /// </summary>
            public JsonStringContent(object obj, Encoding encoding)
                : base(JsonConvert.SerializeObject(obj), encoding, "application/json")
            { }
        }

        #endregion private method
    }
}