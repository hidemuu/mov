using Mov.Analizer.Models;
using Mov.Analizer.Models.Schemas;
using Mov.Analizer.Models.Stores.Commands;
using Mov.Analizer.Models.Stores.Queries;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Stores
{
	public class AnalizerCommand : IAnalizerCommand
	{
		#region field

		private readonly IAnalizerRepository _repository;

		#endregion field

		#region property

		public IStoreCommand<TableLineSchema> TableLines { get; }

		public IStoreCommand<TrendLineSchema> TrendLines { get; }

		public IStoreCommand<TimeLineSchema> TimeLines { get; }

		public IStoreCommand<StatisticLineSchema> StatisticLines { get; }

		public IStoreCommand<HistgramLineSchema> HistgramLines { get; }

		#endregion property

		#region constructor

		public AnalizerCommand(IAnalizerRepository repository)
		{
			_repository = repository;
			this.TableLines = new TableLineCommand(repository);
			this.TrendLines = new TrendLineCommand(repository);
			this.TimeLines = new TimeLineCommand(repository);
			this.StatisticLines = new StatisticLineCommand(repository);
			this.HistgramLines = new HistgramLineCommand(repository);
		}

		#endregion constructor

	}
}
