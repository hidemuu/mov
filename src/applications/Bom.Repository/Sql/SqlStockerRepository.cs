using Bom.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bom.Repository.Sql
{
    public class SqlStockerRepository : IStockerRepository
    {
        private readonly DbContextOptions<StockerDbContext> _dbOptions;

        public SqlStockerRepository(DbContextOptionsBuilder<StockerDbContext>
            dbOptionsBuilder)
        {
            _dbOptions = dbOptionsBuilder.Options;
            using (var db = new StockerDbContext(_dbOptions))
            {
                db.Database.EnsureCreated();
            }
        }

        public ICustomerRepository Customers => new SqlCustomerRepository(
            new StockerDbContext(_dbOptions));

        public IOrderRepository Orders => new SqlOrderRepository(
            new StockerDbContext(_dbOptions));

        public IProductRepository Products => new SqlProductRepository(
            new StockerDbContext(_dbOptions));
    }
}
