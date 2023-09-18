using Microsoft.EntityFrameworkCore;
using Mov.Core.Translators.Models.Schemas;

namespace Mov.Core.Translators.Contexts
{
    public class TranslatorDbContext : DbContext
    {
        #region constructor

        public TranslatorDbContext() { }

        public TranslatorDbContext(DbContextOptions<TranslatorDbContext> options) : base(options)
        {

        }

        #endregion constructor

        #region property

        public DbSet<TranslateSchema> Translates { get; set; }

        #endregion property

        #region event

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        #endregion event
    }
}
