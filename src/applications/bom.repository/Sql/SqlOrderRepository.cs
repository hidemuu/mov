using Mov.Bom.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Bom.Repository.Sql
{
    /// <summary>
    /// Contains methods for interacting with the orders backend using 
    /// SQL via Entity Framework Core 2.0.
    /// </summary>
    public class SqlOrderRepository : IOrderRepository
    {
        private readonly StockerDbContext _db;

        public SqlOrderRepository(StockerDbContext db) => _db = db;

        public async Task<IEnumerable<Order>> GetAsync() =>
            await _db.Orders
                .Include(order => order.LineItems)
                .ThenInclude(lineItem => lineItem.Product)
                .AsNoTracking()
                .ToListAsync();

        public async Task<Order> GetAsync(Guid id) =>
            await _db.Orders
                .Include(order => order.LineItems)
                .ThenInclude(lineItem => lineItem.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(order => order.Id == id);

        public async Task<IEnumerable<Order>> GetForCustomerAsync(Guid id) =>
            await _db.Orders
                .Where(order => order.CustomerId == id)
                .Include(order => order.LineItems)
                .ThenInclude(lineItem => lineItem.Product)
                .AsNoTracking()
                .ToListAsync();

        public async Task<IEnumerable<Order>> GetAsync(string value)
        {
            string[] parameters = value.Split(' ');
            return await _db.Orders
                .Include(order => order.Customer)
                .Include(order => order.LineItems)
                .ThenInclude(lineItem => lineItem.Product)
                .Where(order => parameters
                    .Any(parameter =>
                        order.Address.StartsWith(parameter) ||
                        order.Customer.FirstName.StartsWith(parameter) ||
                        order.Customer.LastName.StartsWith(parameter) ||
                        order.InvoiceNumber.ToString().StartsWith(parameter)))
                .OrderByDescending(order => parameters
                    .Count(parameter =>
                        order.Address.StartsWith(parameter) ||
                        order.Customer.FirstName.StartsWith(parameter) ||
                        order.Customer.LastName.StartsWith(parameter) ||
                        order.InvoiceNumber.ToString().StartsWith(parameter)))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Order> UpsertAsync(Order order)
        {
            var existing = await _db.Orders.FirstOrDefaultAsync(_order => _order.Id == order.Id);
            if (null == existing)
            {
                order.InvoiceNumber = _db.Orders.Max(_order => _order.InvoiceNumber) + 1;
                _db.Orders.Add(order);
            }
            else
            {
                _db.Entry(existing).CurrentValues.SetValues(order);
            }
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task DeleteAsync(Guid orderId)
        {
            var match = await _db.Orders.FindAsync(orderId);
            if (match != null)
            {
                _db.Orders.Remove(match);
            }
            await _db.SaveChangesAsync();
        }
    }
}
