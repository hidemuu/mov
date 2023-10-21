using Mov.Analizer.Models.Schemas;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models
{
	public interface IAnalizerStoreQuery
	{
		IStoreQuery<TimeLineSchema, string> TimeLines { get; }
	}
}
