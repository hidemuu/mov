using Mov.Analizer.Models.Schemas;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Core.Stores;
using Mov.Core.Stores.Services.Queries.Readers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Stores.Queries
{
	public class TimeLineQuery : IStoreQuery<TimeLineSchema, int>
	{
		#region property

		public IRead<TimeLineSchema, int> Reader { get; }

		#endregion property

		#region constructor

		public TimeLineQuery(IAnalizerRepository repository)
		{
			this.Reader = new DbRepositoryReader<IDbRepository<TimeLineSchema, int, DbRequestSchemaString>, TimeLineSchema, int, DbRequestSchemaString>(repository.TimeLines);
		}

		#endregion constructor
	}
}
