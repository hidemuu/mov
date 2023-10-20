using Mov.Core.Commands.Services;
using Mov.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Suite.AnalizerClient.Resas.Controllers
{
	public class ResasCommandController : UiCommandController<string[], string>
	{
		#region field

		private readonly IResasRepository _repository;

		#endregion field

		#region constructor

		public ResasCommandController(IResasRepository repository) 
			: base(new UiCommandFactory<ResasCommandController, string[], string>(), "Controllers.Commands", repository)
		{
			_repository = repository;
		}

		#endregion constructor

	}
}
