using Microsoft.EntityFrameworkCore;
using Mov.Game.Models.Schemas;

namespace Mov.Framework.Contexts
{
    public abstract class MovDbContextBase : DbContext
    {

        #region property

        public string Endpoint { get; }

        public DbSet<LandmarkSchema> Landmarks { get; set; }

        #endregion property

        #region constructor

        public MovDbContextBase(string endpoint)
        { 
            this.Endpoint = endpoint;
        }

        public MovDbContextBase(DbContextOptions<MovDbContextBase> options, string endpoint) : base(options)
        {
            this.Endpoint = endpoint;
        }

        #endregion constructor

        #region event

        protected abstract override void OnConfiguring(DbContextOptionsBuilder optionsBuilder);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        #endregion event
    }
}