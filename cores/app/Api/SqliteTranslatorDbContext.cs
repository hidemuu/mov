using Microsoft.EntityFrameworkCore;
using Mov.Core.Accessors.Models;
using Mov.Core.Translators.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Api
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

            optionsBuilder.UseSqlite(PathValue.Factory.CreateResourcePath(@"translator.sqlite").GetSqliteConnectionString());
            //optionsBuilder.UseLazyLoadingProxies();

        }
    }
}
