using Mov.Analizer.Models;
using Mov.Analizer.Models.Schemas;
using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Services;
using System;
using System.IO;

namespace Mov.Analizer.Repository
{
    public class FileAnalizerRepository : IAnalizerRepository
    {
		#region property

		public IDbRepository<TimeLineSchema, Guid> TimeLines { get; }

		#endregion property

		#region constructor

		public FileAnalizerRepository(string endpoint)
		{
			TimeLines = FileDbRepository<TimeLineSchema, Guid>.Factory.Create(Path.Combine(endpoint, "timeline_json"), FileType.Json, EncodingValue.UTF8);
		}

		#endregion constructor

	}
}
