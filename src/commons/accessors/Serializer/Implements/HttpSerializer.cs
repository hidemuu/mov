using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors.Serializer.Implements
{
    public class HttpSerializer : ISerializer, ISerializerAsync
    {
        #region field

        /// <summary>
        /// The Base URL for the API.
        /// /// </summary>
        private readonly IFileAccessContext context;

        #endregion field

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="endpoint"></param>
        public HttpSerializer(IFileAccessContext context)
        {
            this.context = context;
        }

        #endregion constructor

        #region method

        public TResponse Get<TResponse>(string url)
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

        public TResponse Post<TRequest, TResponse>(string url, TRequest body)
        {
            using (var client = BaseClient())
            {
                var responseTask = client.PostAsync(url, new JsonStringContent(body, this.context.FileParameter.Encoding));
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
                var response = await client.PostAsync(url, new JsonStringContent(body, this.context.FileParameter.Encoding));
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
        private HttpClient BaseClient() => new HttpClient { BaseAddress = new Uri(this.context.FileParameter.FileUnit.Path) };

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