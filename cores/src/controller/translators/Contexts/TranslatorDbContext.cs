using Microsoft.EntityFrameworkCore;
using Mov.Core.Translators.Models.Schemas;

namespace Mov.Core.Translators.Contexts
{
    public class TranslatorDbContext : DbContext
    {
        public TranslatorDbContext() { }

        public TranslatorDbContext(DbContextOptions<TranslatorDbContext> options) : base(options)
        {

        }

        public DbSet<TranslateSchema> Translates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
