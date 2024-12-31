using Mov.Analizer.Models.Schemas;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Core.Repositories;
using Mov.Core.Stores;
using Mov.Core.Stores.Services.Queries.Readers;
using System;
using System.Collections.Generic;
using System.Text;
using Mov.Core.Stores.Services.Queries.Readers.Decorators;

namespace Mov.Analizer.Models.Stores.Queries
{
	public class HistgramLineQuery : IStoreQuery<HistgramLineSchema, string>
	{
		#region property

		public IRead<HistgramLineSchema, string> Reader { get; }

		#endregion property

		#region constructor

		public HistgramLineQuery(IAnalizerRepository repository)
		{
			this.Reader = new ReadCaching<HistgramLineSchema, string>(
				new DbRepositoryReader<IDbRepository<HistgramLineSchema, string, DbRequestSchemaString>, HistgramLineSchema, string, DbRequestSchemaString>(
					repository.HistgramLines));
		}

		#endregion constructor

	}
}
