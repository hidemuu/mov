using Mov.Bom.Models;
using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mov.Bom.Models.Entities.Schemas;
using Mov.Accessors.Serializer.Implements;
using Mov.Accessors.Contexts;

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
            _http = new HttpSerializer(new FileAccessContext(baseUrl));
        }

        public async Task<IEnumerable<Product>> GetAsync() =>
            await _http.GetAsync<IEnumerable<Product>>("product");

        public async Task<Product> GetAsync(Guid id) =>
            await _http.GetAsync<Product>($"product/{id}");

        public async Task<IEnumerable<Product>> GetAsync(string search) =>
            await _http.GetAsync<IEnumerable<Product>>($"product/search?value={search}");
    }
}
