using Mov.Analizer.Models.Schemas;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Core.Repositories;
using Mov.Core.Stores.Services.Queries.Readers;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using Mov.Core.Stores.Services.Queries.Readers.Decorators;

namespace Mov.Analizer.Models.Stores.Queries
{
	public class TrendLineQuery : IStoreQuery<TrendLineSchema, string>
	{
		#region property

		public IRead<TrendLineSchema, string> Reader { get; }

		#endregion property

		#region constructor

		public TrendLineQuery(IAnalizerRepository repository)
		{
			this.Reader = new ReadCaching<TrendLineSchema, string>(
				new DbRepositoryReader<IDbRepository<TrendLineSchema, string, DbRequestSchemaString>, TrendLineSchema, string, DbRequestSchemaString>(
					repository.TrendLines));
		}

		#endregion constructor
	}

}
