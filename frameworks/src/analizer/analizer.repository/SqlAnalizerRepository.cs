using Microsoft.EntityFrameworkCore;
using Mov.Analizer.Models;
using Mov.Core.Repositories.Services;
using Mov.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Mov.Analizer.Models.Schemas;

namespace Mov.Analizer.Repository
{
	public class SqlAnalizerRepository : IAnalizerRepository
	{
		#region field

		private readonly DbContextOptions<AnalizerDbContext> _dbOptions;
		private readonly AnalizerDbContext _db;

		#endregion field

		#region constructor

		public SqlAnalizerRepository(DbContextOptionsBuilder<AnalizerDbContext> dbOptionsBuilder)
		{
			_dbOptions = dbOptionsBuilder.Options;
			using (var db = new AnalizerDbContext(_dbOptions))
			{
				db.Database.EnsureCreated();
			}
			_db = new AnalizerDbContext(_dbOptions);
		}

		#endregion constructor

		#region property

		public IDbRepository<TimeLineSchema, Guid> TimeLines => new SqlDbRepository<TimeLineSchema, Guid>(_db, _db.TimeLines);

		#endregion proeprty

	}
}
