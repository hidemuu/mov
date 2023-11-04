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
		IStoreCommand<TrendLineSchema> TrendLines { get; }
		IStoreCommand<TimeLineSchema> TimeLines { get; }

		IStoreCommand<StatisticLineSchema> StatisticLines { get; }

		IStoreCommand<HistgramLineSchema> HistgramLines { get; }
	}
}
