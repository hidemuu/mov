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
	public class TimeTrendCommand : IStoreCommand<TimeTrendSchema>
	{
		#region property

		public ISave<TimeTrendSchema> Saver { get; }

		public IDelete<TimeTrendSchema> Deleter { get; }

		#endregion property

		#region constructor

		public TimeTrendCommand(IAnalizerRepository repository)
		{
			this.Saver = new DbRepositorySaver<IDbRepository<TimeTrendSchema, string, DbRequestSchemaString>, TimeTrendSchema, string, DbRequestSchemaString>(repository.TimeTrends);
			this.Deleter = new DbRepositoryDeleter<IDbRepository<TimeTrendSchema, string, DbRequestSchemaString>, TimeTrendSchema, string, DbRequestSchemaString>(repository.TimeTrends);
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
