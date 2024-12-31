using Mov.Analizer.Models;
using Mov.Analizer.Models.Schemas;
using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Core.Repositories.Services;
using System;
using System.IO;

namespace Mov.Analizer.Repository
{
    public class FileAnalizerRepository : IAnalizerRepository
    {
		#region property

		public IDbRepository<TimeLineSchema, string, DbRequestSchemaString> TimeLines { get; }

		public IDbRepository<TrendLineSchema, string, DbRequestSchemaString> TrendLines { get; }

		public IDbRepository<TableLineSchema, int, DbRequestSchemaString> TableLines { get; }

		public IDbRepository<StatisticLineSchema, string, DbRequestSchemaString> StatisticLines { get; }

		public IDbRepository<HistgramLineSchema, string, DbRequestSchemaString> HistgramLines { get; }

		#endregion property

		#region constructor

		public FileAnalizerRepository(string endpoint)
		{
			TimeLines = FileDbRepository<TimeLineSchema, string>.Factory.Create(Path.Combine(endpoint, "timeline.json"), FileType.Json, EncodingValue.UTF8);
			TrendLines = FileDbRepository<TrendLineSchema, string>.Factory.Create(Path.Combine(endpoint, "timetrend.json"), FileType.Json, EncodingValue.UTF8);
			TableLines = FileDbRepository<TableLineSchema, int>.Factory.Create(Path.Combine(endpoint, "tableline.json"), FileType.Json, EncodingValue.UTF8);
			StatisticLines = FileDbRepository<StatisticLineSchema, string>.Factory.Create(Path.Combine(endpoint, "statisticline.json"), FileType.Json, EncodingValue.UTF8);
			HistgramLines = FileDbRepository<HistgramLineSchema, string>.Factory.Create(Path.Combine(endpoint, "histgramline.json"), FileType.Json, EncodingValue.UTF8);
		}

		#endregion constructor

	}
}
