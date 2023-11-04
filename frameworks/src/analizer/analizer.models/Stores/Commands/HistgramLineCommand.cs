using Mov.Analizer.Models.Schemas;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Stores.Commands
{
	public class HistgramLineCommand : IStoreCommand<HistgramLineSchema>
	{
		public ISave<HistgramLineSchema> Saver => throw new NotImplementedException();

		public IDelete<HistgramLineSchema> Deleter => throw new NotImplementedException();

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
