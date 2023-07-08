using Microsoft.EntityFrameworkCore;
using Mov.Framework.Contexts;

namespace Mov.UseCase.Contexts
{
    public class InMemoryMovDbContext : MovDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(UseCaseConstants.ResourcePath);

        }
    }
}