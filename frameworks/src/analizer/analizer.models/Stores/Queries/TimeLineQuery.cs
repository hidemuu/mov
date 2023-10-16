using Mov.Analizer.Models.Schemas;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Stores.Queries
{
	public class TimeLineQuery : IStoreQuery<TimeLineSchema, Guid>
	{
		public IRead<TimeLineSchema, Guid> Reader => throw new NotImplementedException();
	}
}
