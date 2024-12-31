using Mov.Core.Accessors.Models;
using Mov.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Accessors.Clients
{
    public class WebClient : IClient
    {
        #region field

        private bool _disposedValue;

        private readonly RequestHeaderSchema _header = RequestHeaderSchema.Empty;

        #endregion field

        #region property

        /// <inheritdoc/>
        public PathValue Endpoint { get; }

        /// <inheritdoc/>
        public EncodingValue Encoding { get; }

        #endregion property

        #region constructor

        public WebClient(PathValue endpoint, EncodingValue encoding, RequestHeaderSchema header)
        {
            Endpoint = endpoint;
            Encoding = encoding;
            _header = header;
        }

        ~WebClient()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: false);
        }

        #endregion constructor

        #region method

        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Makes an HTTP GET request to the given controller and returns the deserialized response content.
        /// </summary>
        public async Task<IEnumerable<TEntity>> GetsAsync<TEntity>(string url)
        {
            using (var client = BaseClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                foreach(var header in _header.Parameters)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
                try
                {
					HttpResponseMessage response = await client.SendAsync(request);
					string json = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<IEnumerable<TEntity>>(json);
				} 
                catch(Exception ex)
                {
					Console.WriteLine(ex.ToString());
					return default(IEnumerable<TEntity>);
				}
                
            }
        }

        public async Task<TEntity> GetAsync<TEntity>(string url)
        {
            using (var client = BaseClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                foreach (var header in _header.Parameters)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
                try
                {
					HttpResponseMessage response = await client.SendAsync(request);
					string json = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<TEntity>(json);
				} 
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return default(TEntity);
                }
                
            }
        }

        /// <summary>
        /// Makes an HTTP POST request to the given controller with the given object as the body.
        /// Returns the deserialized response content.
        /// </summary>
        public async Task<ResponseStatus> PostAsync<TEntity>(string url, TEntity body)
        {
            using (var client = BaseClient())
            {
                try
                {
					var response = await client.PostAsync(url, new JsonStringContent(body, Encoding.Value));
					return ResponseStatus.Success;
					//string json = await response.Content.ReadAsStringAsync();
					//TEntity obj = JsonConvert.DeserializeObject<TEntity>(json);
					//return obj;
				} 
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return ResponseStatus.ServerError;
                }
			}
        }

        /// <summary>
        /// Makes an HTTP POST request to the given controller with the given object as the body.
        /// Returns the deserialized response content.
        /// </summary>
        public async Task<ResponseStatus> PutAsync<TEntity>(string url, TEntity body)
        {
            using (var client = BaseClient())
            {
                try
                {
					var response = await client.PutAsync(url, new JsonStringContent(body, Encoding.Value));
					return ResponseStatus.Success;
					//string json = await response.Content.ReadAsStringAsync();
					//TEntity obj = JsonConvert.DeserializeObject<TEntity>(json);
					//return obj;
				}
				catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
					return ResponseStatus.ServerError;
				}
            }
        }

		public async Task<ResponseStatus> DeletesAsync(string url)
		{
			using (var client = BaseClient())
            {
                try
                {
					await client.DeleteAsync(url);
					return ResponseStatus.Success;
				} 
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.ToString());
					return ResponseStatus.ServerError;
				}
			}
		}


		/// <summary>
		/// Makes an HTTP DELETE request to the given controller and includes all the given
		/// object's properties as URL parameters. Returns the deserialized response content.
		/// </summary>
		public async Task<ResponseStatus> DeleteAsync<TIdentifier>(string url, TIdentifier identifier)
        {
            using (var client = BaseClient())
            {
                try
                {
					var response = await client.DeleteAsync($"{url}/{identifier}");
					return ResponseStatus.Success;
				}
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.ToString());
					return ResponseStatus.ServerError;
				}
            }
        }

        #endregion method

        #region inner method

        /// <summary>
        /// Constructs the base HTTP client, including correct authorization and API version headers.
        /// </summary>
        private HttpClient BaseClient() => new HttpClient { BaseAddress = Endpoint.GetUri() };


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

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージド状態を破棄します (マネージド オブジェクト)
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // TODO: 大きなフィールドを null に設定します
                _disposedValue = true;
            }
        }

		#endregion inner method

	}
}