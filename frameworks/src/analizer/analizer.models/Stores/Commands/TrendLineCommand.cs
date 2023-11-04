using Mov.Analizer.Models.Schemas;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Core.Repositories;
using Mov.Core.Stores.Services.Commands.Deleters;
using Mov.Core.Stores.Services.Commands.Savers;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Stores.Commands
{
	public class TrendLineCommand : IStoreCommand<TrendLineSchema>
	{
		#region property

		public ISave<TrendLineSchema> Saver { get; }

		public IDelete<TrendLineSchema> Deleter { get; }

		#endregion property

		#region constructor

		public TrendLineCommand(IAnalizerRepository repository)
		{
			this.Saver = new DbRepositorySaver<IDbRepository<TrendLineSchema, string, DbRequestSchemaString>, TrendLineSchema, string, DbRequestSchemaString>(repository.TrendLines);
			this.Deleter = new DbRepositoryDeleter<IDbRepository<TrendLineSchema, string, DbRequestSchemaString>, TrendLineSchema, string, DbRequestSchemaString>(repository.TrendLines);
		}

		#endregion constructor

		#region method

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		#endregion method
	}
}
