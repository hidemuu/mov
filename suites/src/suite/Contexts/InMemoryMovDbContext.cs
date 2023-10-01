using Microsoft.EntityFrameworkCore;
using Mov.Framework.Contexts;

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
