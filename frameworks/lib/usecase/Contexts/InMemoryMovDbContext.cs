using Microsoft.EntityFrameworkCore;
using Mov.Framework.Contexts;

namespace Mov.UseCase.Contexts
{
    public class InMemoryMovDbContext : MovDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = new SqliteConnectionStringBuilder { DataSource = Constants.RootPath + @"\assets\covid\" + @"covid.db" }.ToString();
            optionsBuilder.UseInMemoryDatabase(UseCaseConstants.ResourcePath);

        }
    }
}