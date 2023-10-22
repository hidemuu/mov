using Mov.Analizer.Models.Schemas;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models
{
	public interface IAnalizerStoreCommand
	{
		IStoreCommand<TableLineSchema> TableLines { get; }
		IStoreCommand<TimeTrendSchema> TimeTrends { get; }
		IStoreCommand<TimeLineSchema> TimeLines { get; }
	}
}
