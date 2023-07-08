using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Repositories.Contexts
{
    public class MovDbContextCore : DbContext
    {
        #region constructor

        public MovDbContextCore()
        { }

        public MovDbContextCore(DbContextOptions<MovDbContextCore> options) : base(options)
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
