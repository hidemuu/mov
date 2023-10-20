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
	public class TimeLineQuery : IStoreQuery<TimeLineSchema, Guid>
	{
		#region property

		public IRead<TimeLineSchema, Guid> Reader { get; }

		#endregion property

		#region constructor

		public TimeLineQuery(IAnalizerRepository repository)
		{
			this.Reader = new DbRepositoryReader<IDbRepository<TimeLineSchema, Guid, DbRequestSchemaString>, TimeLineSchema, Guid, DbRequestSchemaString>(repository.TimeLines);
		}

		#endregion constructor
	}
}
