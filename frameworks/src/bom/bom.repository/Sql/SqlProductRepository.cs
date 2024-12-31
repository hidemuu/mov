using Microsoft.EntityFrameworkCore;
using Mov.Bom.Models;
using Mov.Bom.Models.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Bom.Repository.Sql
{
    /// <summary>
    /// Contains methods for interacting with the products backend using
    /// SQL via Entity Framework Core 2.0.
    /// </summary>
    public class SqlProductRepository : IProductRepository
    {
        private readonly BomDbContext _db;

        public SqlProductRepository(BomDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _db.Products
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product> GetAsync(Guid id)
        {
            return await _db.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(product => product.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAsync(string value)
        {
            return await _db.Products.Where(product =>
                product.Name.StartsWith(value) ||
                product.Color.StartsWith(value) ||
                product.DaysToManufacture.ToString().StartsWith(value) ||
                product.StandardCost.ToString().StartsWith(value) ||
                product.ListPrice.ToString().StartsWith(value) ||
                product.Weight.ToString().StartsWith(value) ||
                product.Description.StartsWith(value))
            .AsNoTracking()
            .ToListAsync();
        }
    }
}