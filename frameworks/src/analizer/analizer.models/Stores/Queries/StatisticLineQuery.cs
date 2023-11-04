using Mov.Analizer.Models.Schemas;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Stores.Queries
{
	public class StatisticLineQuery : IStoreQuery<StatisticLineSchema, string>
	{
		public IRead<StatisticLineSchema, string> Reader => throw new NotImplementedException();
	}
}
