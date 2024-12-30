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
	public class TableLineQuery : IStoreQuery<TableLineSchema, int>
	{
		#region property

		public IRead<TableLineSchema, int> Reader { get; }

		#endregion property

		#region constructor

		public TableLineQuery(IAnalizerRepository repository)
		{
			this.Reader = new ReadCaching<TableLineSchema, int>(
				new DbRepositoryReader<IDbRepository<TableLineSchema, int, DbRequestSchemaString>, TableLineSchema, int, DbRequestSchemaString>(
					repository.TableLines));
		}

		#endregion constructor
	}
}
