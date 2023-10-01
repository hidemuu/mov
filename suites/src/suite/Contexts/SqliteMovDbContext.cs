using Microsoft.EntityFrameworkCore;
using Mov.Framework.Contexts;

namespace Mov.Suite.Contexts
{
    public class SqliteMovDbContext : MovDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = new SqliteConnectionStringBuilder { DataSource = Constants.RootPath + @"\assets\covid\" + @"covid.db" }.ToString();
            optionsBuilder.UseSqlite(SuiteConstants.SqlLocalConnectionStringForSqlite);

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // 複合キーの場合、以下のように指定してやる。
        //    // ない場合「Entity type 'Item' has composite primary key defined with data annotations. To set composite primary key, use fluent API.」と表示される
        //    //modelBuilder.Entity<Item>().HasKey(c => new { c.Id, c.PointNo });
        //}
    }
}
