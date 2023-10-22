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
	public class TableLineCommand : IStoreCommand<TableLineSchema>
	{
		#region property

		public ISave<TableLineSchema> Saver { get; }

		public IDelete<TableLineSchema> Deleter { get; }

		#endregion property

		#region constructor

		public TableLineCommand(IAnalizerRepository repository)
		{
			this.Saver = new DbRepositorySaver<IDbRepository<TableLineSchema, int, DbRequestSchemaString>, TableLineSchema, int, DbRequestSchemaString>(repository.TableLines);
			this.Deleter = new DbRepositoryDeleter<IDbRepository<TableLineSchema, int, DbRequestSchemaString>, TableLineSchema, int, DbRequestSchemaString>(repository.TableLines);
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
