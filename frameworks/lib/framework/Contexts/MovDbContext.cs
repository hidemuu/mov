using Microsoft.EntityFrameworkCore;
using Mov.Core.Repositories.Contexts;
using Mov.Game.Models.Schemas;

namespace Mov.Framework.Contexts
{
    public class MovDbContext : DbContext
    {
        #region property

        public DbSet<LandmarkSchema> Landmarks { get; set; }

        #endregion property

        #region constructor

        public MovDbContext()
        { }

        public MovDbContext(DbContextOptions<MovDbContext> options) : base(options)
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