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

		public IDbRepository<TimeLineSchema, Guid, DbRequestSchemaString> TimeLines { get; }

		public IDbRepository<TimeTrendSchema, Guid, DbRequestSchemaString> TimeTrends { get; }

		public IDbRepository<TableLineSchema, Guid, DbRequestSchemaString> TableLines { get; }

		#endregion property

		#region constructor

		public FileAnalizerRepository(string endpoint)
		{
			TimeLines = FileDbRepository<TimeLineSchema, Guid>.Factory.Create(Path.Combine(endpoint, "timeline_json"), FileType.Json, EncodingValue.UTF8);
			TimeTrends = FileDbRepository<TimeTrendSchema, Guid>.Factory.Create(Path.Combine(endpoint, "timetrend_json"), FileType.Json, EncodingValue.UTF8);
			TableLines = FileDbRepository<TableLineSchema, Guid>.Factory.Create(Path.Combine(endpoint, "tableline_json"), FileType.Json, EncodingValue.UTF8);
		}

		#endregion constructor

	}
}
