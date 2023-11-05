using Mov.Analizer.Models;
using Mov.Analizer.Models.Schemas;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Core.Repositories.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Repository
{
	public class InMemoryAnalizerRepository : IAnalizerRepository
	{
		#region property

		public IDbRepository<TableLineSchema, int, DbRequestSchemaString> TableLines { get; }

		public IDbRepository<TimeLineSchema, string, DbRequestSchemaString> TimeLines { get; }

		public IDbRepository<TrendLineSchema, string, DbRequestSchemaString> TrendLines { get; }

		public IDbRepository<StatisticLineSchema, string, DbRequestSchemaString> StatisticLines { get; }

		public IDbRepository<HistgramLineSchema, string, DbRequestSchemaString> HistgramLines { get; }

		#endregion property

		#region constructor

		public InMemoryAnalizerRepository() 
		{
			this.TableLines = new InMemoryDbRepository<TableLineSchema, int>("tableline");
			this.TimeLines = new InMemoryDbRepository<TimeLineSchema, string>("timeline");
			this.TrendLines = new InMemoryDbRepository<TrendLineSchema, string>("trendline");
			this.StatisticLines = new InMemoryDbRepository<StatisticLineSchema, string>("statisticline");
			this.HistgramLines = new InMemoryDbRepository<HistgramLineSchema, string>("histgramline");
		}

		#endregion constructor
	}
}
