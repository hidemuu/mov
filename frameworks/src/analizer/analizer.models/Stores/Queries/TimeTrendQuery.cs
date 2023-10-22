using Mov.Analizer.Models.Schemas;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Core.Repositories;
using Mov.Core.Stores.Services.Queries.Readers;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Stores.Queries
{
	public class TimeTrendQuery : IStoreQuery<TimeTrendSchema, string>
	{
		#region property

		public IRead<TimeTrendSchema, string> Reader { get; }

		#endregion property

		#region constructor

		public TimeTrendQuery(IAnalizerRepository repository)
		{
			this.Reader = new DbRepositoryReader<IDbRepository<TimeTrendSchema, string, DbRequestSchemaString>, TimeTrendSchema, string, DbRequestSchemaString>(repository.TimeTrends);
		}

		#endregion constructor
	}

}
