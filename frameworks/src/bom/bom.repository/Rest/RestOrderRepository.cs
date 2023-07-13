using Mov.Bom.Models;
using Mov.Bom.Models.Entities.Schemas;
using Mov.Core.Accessors.Services;
using Mov.Core.Accessors.Services.Serializer.Implements;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mov.Bom.Repository.Rest
{
    /// <summary>
    /// Contains methods for interacting with the orders backend using REST.
    /// </summary>
    public class RestOrderRepository : IOrderRepository
    {
        private readonly HttpSerializer _http;

        public RestOrderRepository(string baseUrl)
        {
            _http = new HttpSerializer(new FileAccessService(baseUrl));
        }

        public async Task<IEnumerable<Order>> GetAsync() =>
            await _http.GetAsync<IEnumerable<Order>>("order");

        public async Task<Order> GetAsync(Guid id) =>
            await _http.GetAsync<Order>($"order/{id}");

        public async Task<IEnumerable<Order>> GetForCustomerAsync(Guid customerId) =>
            await _http.GetAsync<IEnumerable<Order>>($"order/customer/{customerId}");

        public async Task<IEnumerable<Order>> GetAsync(string search) =>
            await _http.GetAsync<IEnumerable<Order>>($"order/search?value={search}");

        public async Task<Order> UpsertAsync(Order order) =>
            await _http.PostAsync<Order, Order>("order", order);

        public async Task DeleteAsync(Guid orderId) =>
            await _http.DeleteAsync("order", orderId.ToString());
    }
}