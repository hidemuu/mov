using Microsoft.EntityFrameworkCore;
using Mov.Bom.Models.Schemas;

namespace Mov.Bom.Repository
{
    public class BomDbContext : DbContext
    {
        public BomDbContext()
        { }

        /// <summary>
        /// Creates a new Contoso DbContext.
        /// </summary>
        public BomDbContext(DbContextOptions<BomDbContext> options) : base(options)
        { }

        /// <summary>
        /// Gets the customers DbSet.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets the orders DbSet.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets the products DbSet.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets the line items DbSet.
        /// </summary>
        public DbSet<LineItem> LineItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}