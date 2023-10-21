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

		public IStoreQuery<TimeLineSchema, string> TimeLines { get; }

		#endregion property

		#region constructor

		public AnalizerStoreQuery(IAnalizerRepository repository)
		{
			_repository= repository;
			this.TimeLines = new TimeLineQuery(repository);
		}

		#endregion constructor
	}
}
