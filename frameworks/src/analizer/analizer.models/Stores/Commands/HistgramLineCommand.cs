using Mov.Analizer.Models.Schemas;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Core.Repositories;
using Mov.Core.Stores;
using Mov.Core.Stores.Services.Commands.Savers;
using System;
using System.Collections.Generic;
using System.Text;
using Mov.Core.Stores.Services.Commands.Deleters;

namespace Mov.Analizer.Models.Stores.Commands
{
	public class HistgramLineCommand : IStoreCommand<HistgramLineSchema>
	{
		#region property

		public ISave<HistgramLineSchema> Saver { get; }

		public IDelete<HistgramLineSchema> Deleter { get; }

		#endregion property

		#region constructor

		public HistgramLineCommand(IAnalizerRepository repository)
		{
			this.Saver = new DbRepositorySaver<IDbRepository<HistgramLineSchema, string, DbRequestSchemaString>, HistgramLineSchema, string, DbRequestSchemaString>(repository.HistgramLines);
			this.Deleter = new DbRepositoryDeleter<IDbRepository<HistgramLineSchema, string, DbRequestSchemaString>, HistgramLineSchema, string, DbRequestSchemaString>(repository.HistgramLines);
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
