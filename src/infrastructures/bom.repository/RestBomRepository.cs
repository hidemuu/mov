using Mov.Bom.Models;
using Mov.Bom.Repository.Rest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Bom.Repository
{
    public class RestBomRepository : IBomRepository
    {
        private readonly string _url;

        public RestBomRepository(string url)
        {
            _url = url;
        }

        public ICustomerRepository Customers => new RestCustomerRepository(_url);

        public IOrderRepository Orders => new RestOrderRepository(_url);

        public IProductRepository Products => new RestProductRepository(_url);
    }
}
