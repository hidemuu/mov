using Mov.Bom.Models;
using Mov.Bom.Models.Schemas;
using Mov.Core.Accessors.Models;
using Mov.Core.Accessors.Serializer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mov.Bom.Repository.Rest
{
    /// <summary>
    /// Contains methods for interacting with the products backend using REST.
    /// </summary>
    public class RestProductRepository : IProductRepository
    {
        private readonly HttpSerializer _http;

        public RestProductRepository(string baseUrl)
        {
            _http = new HttpSerializer(new PathValue(baseUrl), EncodingValue.UTF8);
        }

        public async Task<IEnumerable<Product>> GetAsync() =>
            await _http.GetAsync<IEnumerable<Product>>("product");

        public async Task<Product> GetAsync(Guid id) =>
            await _http.GetAsync<Product>($"product/{id}");

        public async Task<IEnumerable<Product>> GetAsync(string search) =>
            await _http.GetAsync<IEnumerable<Product>>($"product/search?value={search}");
    }
}