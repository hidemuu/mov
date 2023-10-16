using Mov.Analizer.Models.Schemas;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Stores.Commands
{
	public class TimeLineCommand : IStoreCommand<TimeLineSchema>
	{
		public ISave<TimeLineSchema> Saver => throw new NotImplementedException();

		public IDelete<TimeLineSchema> Deleter => throw new NotImplementedException();

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
