using Mov.Analizer.Models.Schemas;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models
{
	public interface IAnalizerQuery
	{
		IStoreQuery<TableLineSchema, int> TableLines { get; }
		IStoreQuery<TrendLineSchema, string> TrendLines { get; }
		IStoreQuery<TimeLineSchema, string> TimeLines { get; }

		IStoreQuery<StatisticLineSchema, string> StatisticLines { get; }

		IStoreQuery<HistgramLineSchema, string> HistgramLines { get; }
	}
}
