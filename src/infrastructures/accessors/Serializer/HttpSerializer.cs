using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors.Serializer
{
    public class HttpSerializer : ISerializer
    {
        #region フィールド

        /// <summary>
        /// The Base URL for the API.
        /// /// </summary>
        private readonly string endpoint;
        private readonly string url;

        #endregion フィールド

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="baseUrl"></param>
        public HttpSerializer(string endpoint, string url = "")
        {
            this.endpoint = endpoint;
            this.url = string.IsNullOrEmpty(url) ? endpoint : url;
        }

        #endregion コンストラクター

        #region メソッド

        public T Read<T>()
        {
            using (var client = BaseClient())
            {
                var responseTask = client.GetAsync(this.url);
                Task.WhenAll(responseTask);
                var jsonTask = responseTask.Result.Content.ReadAsStringAsync();
                Task.WhenAll(jsonTask);
                T obj = JsonConvert.DeserializeObject<T>(jsonTask.Result);
                return obj;
            }
        }

        public void Write<T>(T body)
        {
            using (var client = BaseClient())
            {
                var responseTask = client.PostAsync(this.url, new JsonStringContent(body));
                Task.WhenAll(responseTask);
            }
        }

        /// <summary>
        /// Makes an HTTP GET request to the given controller and returns the deserialized response content.
        /// </summary>
        public async Task<T> GetAsync<T>(string url)
        {
            using (var client = BaseClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                T obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }
        }

        /// <summary>
        /// Makes an HTTP POST request to the given controller with the given object as the body.
        /// Returns the deserialized response content.
        /// </summary>
        public async Task<T> PostAsync<TRequest, T>(string url, TRequest body)
        {
            using (var client = BaseClient())
            {
                var response = await client.PostAsync(url, new JsonStringContent(body));
                string json = await response.Content.ReadAsStringAsync();
                T obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }
        }

        /// <summary>
        /// Makes an HTTP DELETE request to the given controller and includes all the given
        /// object's properties as URL parameters. Returns the deserialized response content.
        /// </summary>
        public async Task DeleteAsync(string url, Guid objectId)
        {
            using (var client = BaseClient())
            {
                await client.DeleteAsync($"{url}/{objectId}");
            }
        }

        #endregion メソッド

        #region 内部メソッド

        /// <summary>
        /// Constructs the base HTTP client, including correct authorization and API version headers.
        /// </summary>
        private HttpClient BaseClient() => new HttpClient { BaseAddress = new Uri(this.endpoint) };

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

        #endregion 内部メソッド
    }
}