using Mov.Analizer.Models.Schemas;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Core.Repositories;
using Mov.Core.Stores;
using Mov.Core.Stores.Services.Commands.Deleters;
using Mov.Core.Stores.Services.Commands.Savers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Stores.Commands
{
	public class StatisticLineCommand : IStoreCommand<StatisticLineSchema>
	{
		#region property

		public ISave<StatisticLineSchema> Saver { get; }

		public IDelete<StatisticLineSchema> Deleter { get; }

		#endregion property

		#region constructor

		public StatisticLineCommand(IAnalizerRepository repository)
		{
			this.Saver = new DbRepositorySaver<IDbRepository<StatisticLineSchema, string, DbRequestSchemaString>, StatisticLineSchema, string, DbRequestSchemaString>(repository.StatisticLines);
			this.Deleter = new DbRepositoryDeleter<IDbRepository<StatisticLineSchema, string, DbRequestSchemaString>, StatisticLineSchema, string, DbRequestSchemaString>(repository.StatisticLines);
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
