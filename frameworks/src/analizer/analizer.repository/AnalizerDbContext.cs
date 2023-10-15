using Microsoft.EntityFrameworkCore;
using Mov.Analizer.Models.Schemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Repository
{
	public class AnalizerDbContext : DbContext
	{
		#region constructor

		public AnalizerDbContext() { }

		public AnalizerDbContext(DbContextOptions<AnalizerDbContext> options) : base(options)
		{

		}

		#endregion constructor

		#region property

		public DbSet<TimeLineSchema> TimeLines { get; set; }

		#endregion property

		#region event

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}

		#endregion event
	}
}
