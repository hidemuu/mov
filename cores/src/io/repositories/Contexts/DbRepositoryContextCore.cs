using Microsoft.EntityFrameworkCore;

namespace Mov.Core.Repositories.Contexts
{
    public class DbRepositoryContextCore : DbContext
    {
        #region constructor

        public DbRepositoryContextCore()
        { }

        public DbRepositoryContextCore(DbContextOptions<DbRepositoryContextCore> options) : base(options)
        {
        }

        #endregion constructor

        #region event

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        #endregion event
    }
}
