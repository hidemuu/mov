using Mov.Analizer.Models.Schemas;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Core.Repositories;
using Mov.Core.Stores;
using Mov.Core.Stores.Services.Queries.Readers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Stores.Queries
{
	public class StatisticLineQuery : IStoreQuery<StatisticLineSchema, string>
	{
		#region property

		public IRead<StatisticLineSchema, string> Reader { get; }

		#endregion property

		#region constructor

		public StatisticLineQuery(IAnalizerRepository repository)
		{
			this.Reader = new DbRepositoryReader<IDbRepository<StatisticLineSchema, string, DbRequestSchemaString>, StatisticLineSchema, string, DbRequestSchemaString>(repository.StatisticLines);
		}

		#endregion constructor
	}
}
