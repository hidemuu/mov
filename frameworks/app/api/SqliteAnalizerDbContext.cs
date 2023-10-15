using Microsoft.EntityFrameworkCore;
using Mov.Analizer.Repository;
using Mov.Core.Accessors.Models;

namespace Mov.Api
{
	/// <summary>
	/// 
	/// </summary>
	public class SqliteAnalizerDbContext : AnalizerDbContext
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="optionsBuilder"></param>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(PathValue.Factory.CreateResourcePath("mov", @"analizer.sqlite").GetSqliteConnectionString());
			//optionsBuilder.UseLazyLoadingProxies();

		}
	}
}
