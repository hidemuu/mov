using Mov.Analizer.Models;
using Mov.Core.Accessors.Models;
using Mov.Core.Repositories.Services;
using Mov.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Mov.Analizer.Models.Schemas;

namespace Mov.Analizer.Repository
{
	public class RestAnalizerRepository : IAnalizerRepository
	{
		#region field

		private readonly string _url;
		private readonly string _key;

		#endregion field

		#region property

		public IDbRepository<TimeLineSchema, Guid> TimeLines => new RestDbRepository<TimeLineSchema, Guid>(_url, _key, EncodingValue.UTF8, new Dictionary<string, string>());
		public IDbRepository<TimeTrendSchema, Guid> TimeTrends => new RestDbRepository<TimeTrendSchema, Guid>(_url, _key, EncodingValue.UTF8, new Dictionary<string, string>());
		public IDbRepository<TableLineSchema, Guid> TableLines => new RestDbRepository<TableLineSchema, Guid>(_url, _key, EncodingValue.UTF8, new Dictionary<string, string>());

		#endregion property

		#region constructor

		public RestAnalizerRepository(string url, string auth)
		{
			_url = url;
			_key = auth;
		}

		#endregion constructor
	}
}
