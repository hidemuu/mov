using Microsoft.EntityFrameworkCore;
using Mov.Framework.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Suite.Contexts
{
    public class InMemoryMovDbContext : MovDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(SuiteConstants.ResourcePath);

        }
    }
}
