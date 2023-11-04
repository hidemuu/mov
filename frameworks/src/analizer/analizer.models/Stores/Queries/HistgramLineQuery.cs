using Mov.Analizer.Models.Schemas;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Stores.Queries
{
	public class HistgramLineQuery : IStoreQuery<HistgramLineSchema, string>
	{
		public IRead<HistgramLineSchema, string> Reader => throw new NotImplementedException();
	}
}
