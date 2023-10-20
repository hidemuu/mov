using Mov.Core.Commands.Services;
using Mov.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Suite.AnalizerClient.Resas.Controllers
{
	public class ResasConsoleController : UiCommandController<string[], string>
	{
		#region field

		private readonly IResasRepository _repository;

		#endregion field

		#region constructor

		public ResasConsoleController(IResasRepository repository) 
			: base(new UiCommandFactory<ResasConsoleController, string[], string>(), "Controllers.Commands", repository)
		{
			_repository = repository;

		}

		#endregion constructor

		#region method

		public string GetCities(IEnumerable<string> parameters)
		{
			var city = Task.WhenAll(_repository.Cities.GetAsync(null)).Result[0];
			var response = $"{city.Id}{Environment.NewLine}";
			foreach (var result in city.Results)
			{
				response += $"{result}{Environment.NewLine}";
			}
			Console.WriteLine(response);
			return response;
		}

		public string GetPrefectures(IEnumerable<string> parameters)
		{
			var prefecture = Task.WhenAll(_repository.Prefectures.GetAsync(null)).Result[0];
			var response = $"{prefecture.Id}{Environment.NewLine}";
			foreach (var result in prefecture.Results)
			{
				response += $"{result}{Environment.NewLine}";
			}
			Console.WriteLine(response);
			return response;
		}

		#endregion method
	}
}
