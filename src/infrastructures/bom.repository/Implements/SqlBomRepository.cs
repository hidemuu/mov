using Mov.Bom.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Bom.Repository.Sql
{
    public class SqlBomRepository : IBomRepository
    {
        private readonly DbContextOptions<BomDbContext> dbOptions;

        public SqlBomRepository(DbContextOptionsBuilder<BomDbContext> dbOptionsBuilder)
        {
            this.dbOptions = dbOptionsBuilder.Options;
            using (var db = new BomDbContext(this.dbOptions))
            {
                db.Database.EnsureCreated();
            }
        }

        public ICustomerRepository Customers => new SqlCustomerRepository(
            new BomDbContext(this.dbOptions));

        public IOrderRepository Orders => new SqlOrderRepository(
            new BomDbContext(this.dbOptions));

        public IProductRepository Products => new SqlProductRepository(
            new BomDbContext(this.dbOptions));
    }
}
