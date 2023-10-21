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

		public IDbRepository<TimeTrendSchema, string, DbRequestSchemaString> TimeTrends { get; }

		public IDbRepository<TableLineSchema, int, DbRequestSchemaString> TableLines { get; }

		#endregion property

		#region constructor

		public FileAnalizerRepository(string endpoint)
		{
			TimeLines = FileDbRepository<TimeLineSchema, string>.Factory.Create(Path.Combine(endpoint, "timeline.json"), FileType.Json, EncodingValue.UTF8);
			TimeTrends = FileDbRepository<TimeTrendSchema, string>.Factory.Create(Path.Combine(endpoint, "timetrend.json"), FileType.Json, EncodingValue.UTF8);
			TableLines = FileDbRepository<TableLineSchema, int>.Factory.Create(Path.Combine(endpoint, "tableline.json"), FileType.Json, EncodingValue.UTF8);
		}

		#endregion constructor

	}
}
