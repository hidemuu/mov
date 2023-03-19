using Mov.Bom.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Mov.Bom.Repository.Sql;

namespace Mov.Bom.Repository
{
    public class SqlBomRepository : IBomRepository
    {
        private readonly DbContextOptions<BomDbContext> dbOptions;

        public SqlBomRepository(DbContextOptionsBuilder<BomDbContext> dbOptionsBuilder)
        {
            dbOptions = dbOptionsBuilder.Options;
            using (var db = new BomDbContext(dbOptions))
            {
                db.Database.EnsureCreated();
            }
        }

        public ICustomerRepository Customers => new SqlCustomerRepository(
            new BomDbContext(dbOptions));

        public IOrderRepository Orders => new SqlOrderRepository(
            new BomDbContext(dbOptions));

        public IProductRepository Products => new SqlProductRepository(
            new BomDbContext(dbOptions));
    }
}
