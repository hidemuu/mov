﻿using Mov.Bom.Models;
using Mov.Accessors;
using Mov.Accessors.Serializer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Bom.Repository.Rest
{
    /// <summary>
    /// Contains methods for interacting with the customers backend using REST. 
    /// </summary>
    public class RestCustomerRepository : ICustomerRepository
    {
        private readonly HttpSerializer serializer;

        public RestCustomerRepository(string baseUrl)
        {
            this.serializer = new HttpSerializer(baseUrl);
        }

        public async Task<IEnumerable<Customer>> GetAsync() =>
            await this.serializer.GetAsync<IEnumerable<Customer>>("customer");

        public async Task<IEnumerable<Customer>> GetAsync(string search) =>
            await this.serializer.GetAsync<IEnumerable<Customer>>($"customer/search?value={search}");

        public async Task<Customer> GetAsync(Guid id) =>
            await this.serializer.GetAsync<Customer>($"customer/{id}");

        public async Task<Customer> UpsertAsync(Customer customer) =>
            await this.serializer.PostAsync<Customer, Customer>("customer", customer);

        public async Task DeleteAsync(Guid customerId) =>
            await this.serializer.DeleteAsync("customer", customerId.ToString());
    }
}