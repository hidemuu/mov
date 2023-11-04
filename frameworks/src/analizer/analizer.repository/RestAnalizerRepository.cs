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

		public IDbRepository<TimeLineSchema, string, DbRequestSchemaString> TimeLines => new RestDbRepository<TimeLineSchema, string, DbRequestSchemaString>(_url, EncodingValue.UTF8, RequestHeaderSchema.Empty, "timelines");
		public IDbRepository<TrendLineSchema, string, DbRequestSchemaString> TimeTrends => new RestDbRepository<TrendLineSchema, string, DbRequestSchemaString>(_url, EncodingValue.UTF8, RequestHeaderSchema.Empty, "timetrends");
		public IDbRepository<TableLineSchema, int, DbRequestSchemaString> TableLines => new RestDbRepository<TableLineSchema, int, DbRequestSchemaString>(_url, EncodingValue.UTF8, RequestHeaderSchema.Empty, "tablelines");

		#endregion property

		#region constructor

		public RestAnalizerRepository(string url)
		{
			_url = url;
		}

		#endregion constructor
	}
}
