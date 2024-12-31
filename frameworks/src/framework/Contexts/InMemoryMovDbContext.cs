using Microsoft.EntityFrameworkCore;
using Mov.Framework.Contexts;

namespace Mov.Framework.Contexts
{
    public class InMemoryMovDbContext : MovDbContextBase
    {
        public InMemoryMovDbContext(string endpoint) : base(endpoint)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(SuiteConstants.ResourcePath);
            optionsBuilder.UseInMemoryDatabase(Endpoint);
        }
    }
}
