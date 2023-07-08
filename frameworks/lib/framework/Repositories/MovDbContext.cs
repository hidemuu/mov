using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Framework.Repositories
{
    public class MovDbContext : DbContext
    {
        #region property

        //public DbSet<Infection> Infections { get; set; }

        #endregion property

        #region constructor

        public MovDbContext() { }

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
