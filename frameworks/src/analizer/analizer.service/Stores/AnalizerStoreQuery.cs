using Mov.Analizer.Models;
using Mov.Analizer.Models.Schemas;
using Mov.Analizer.Models.Stores.Queries;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Stores
{
	public class AnalizerStoreQuery : IAnalizerStoreQuery
	{
		#region field

		private readonly IAnalizerRepository _repository;

		#endregion field

		#region property

		public IStoreQuery<TableLineSchema, int> TableLines { get; }

		public IStoreQuery<TrendLineSchema, string> TrendLines { get; }

		public IStoreQuery<TimeLineSchema, string> TimeLines { get; }

		public IStoreQuery<StatisticLineSchema, string> StatisticLines { get; }

		public IStoreQuery<HistgramLineSchema, string> HistgramLines { get; }

		#endregion property

		#region constructor

		public AnalizerStoreQuery(IAnalizerRepository repository)
		{
			_repository= repository;
			this.TableLines = new TableLineQuery(repository);
			this.TrendLines = new TrendLineQuery(repository);
			this.TimeLines = new TimeLineQuery(repository);
			this.StatisticLines = new StatisticLineQuery(repository);
			this.HistgramLines = new HistgramLineQuery(repository);
		}

		#endregion constructor
	}
}
