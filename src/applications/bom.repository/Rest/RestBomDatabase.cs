using Mov.Bom.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Bom.Repository.Rest
{
    public class RestBomDatabase : IBomDatabase
    {
        private readonly string _url;

        public RestBomDatabase(string url)
        {
            _url = url;
        }

        public ICustomerRepository Customers => new RestCustomerRepository(_url);

        public IOrderRepository Orders => new RestOrderRepository(_url);

        public IProductRepository Products => new RestProductRepository(_url);
    }
}
