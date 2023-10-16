using Mov.Analizer.Models;
using Mov.Analizer.Models.Schemas;
using Mov.Analizer.Models.Stores.Commands;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Stores
{
	public class AnalizerStoreCommand : IAnalizerStoreCommand
	{
		#region field

		private readonly IAnalizerRepository _repository;

		#endregion field

		#region property

		public IStoreCommand<TimeLineSchema> TimeLines { get; }

		#endregion property

		#region constructor

		public AnalizerStoreCommand(IAnalizerRepository repository)
		{
			_repository = repository;
			this.TimeLines = new TimeLineCommand();
		}

		#endregion constructor

	}
}
