using Mov.Analizer.Models.Schemas;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Stores.Commands
{
	public class StatisticLineCommand : IStoreCommand<StatisticLineSchema>
	{
		public ISave<StatisticLineSchema> Saver => throw new NotImplementedException();

		public IDelete<StatisticLineSchema> Deleter => throw new NotImplementedException();

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
