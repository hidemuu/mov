using Mov.Analizer.Models;
using Mov.Core.Accessors.Models;
using Mov.Core.Repositories.Services;
using Mov.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Mov.Analizer.Models.Schemas;
using Mov.Core.Repositories.Schemas.Requests;

namespace Mov.Analizer.Repository
{
	public class RestAnalizerRepository : IAnalizerRepository
	{
		#region field

		private readonly string _url;

		#endregion field

		#region property

		public IDbRepository<TimeLineSchema, Guid, DbRequestSchemaString> TimeLines => new RestDbRepository<TimeLineSchema, Guid, DbRequestSchemaString>(_url, EncodingValue.UTF8, new Dictionary<string, string>());
		public IDbRepository<TimeTrendSchema, Guid, DbRequestSchemaString> TimeTrends => new RestDbRepository<TimeTrendSchema, Guid, DbRequestSchemaString>(_url, EncodingValue.UTF8, new Dictionary<string, string>());
		public IDbRepository<TableLineSchema, Guid, DbRequestSchemaString> TableLines => new RestDbRepository<TableLineSchema, Guid, DbRequestSchemaString>(_url, EncodingValue.UTF8, new Dictionary<string, string>());

		#endregion property

		#region constructor

		public RestAnalizerRepository(string url)
		{
			_url = url;
		}

		#endregion constructor
	}
}
