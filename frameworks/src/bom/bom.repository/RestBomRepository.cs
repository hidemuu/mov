using Mov.Bom.Models;
using Mov.Bom.Repository.Rest;

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