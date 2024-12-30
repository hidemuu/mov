using Microsoft.EntityFrameworkCore;
using Mov.Core.Accessors.Models;
using Mov.Core.Translators.Contexts;

namespace Mov.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class SqliteTranslatorDbContext : TranslatorDbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(PathValue.Factory.CreateResourcePath("mov", @"translator.sqlite").GetSqliteConnectionString());
            //optionsBuilder.UseLazyLoadingProxies();

        }
    }
}
