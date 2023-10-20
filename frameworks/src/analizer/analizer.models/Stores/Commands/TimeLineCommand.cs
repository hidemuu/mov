using Mov.Analizer.Models.Schemas;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Core.Stores;
using Mov.Core.Stores.Services.Commands.Deleters;
using Mov.Core.Stores.Services.Commands.Savers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Stores.Commands
{
	public class TimeLineCommand : IStoreCommand<TimeLineSchema>
	{
		#region property

		public ISave<TimeLineSchema> Saver { get; }

		public IDelete<TimeLineSchema> Deleter { get; }

		#endregion property

		#region constructor

		public TimeLineCommand(IAnalizerRepository repository)
		{
			this.Saver = new DbRepositorySaver<IDbRepository<TimeLineSchema, Guid, DbRequestSchemaString>, TimeLineSchema, Guid, DbRequestSchemaString>(repository.TimeLines);
			this.Deleter = new DbRepositoryDeleter<IDbRepository<TimeLineSchema, Guid, DbRequestSchemaString>, TimeLineSchema, Guid, DbRequestSchemaString>(repository.TimeLines);
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
