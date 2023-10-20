using Mov.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Suite.AnalizerClient.Resas.Controllers.Commands
{
	public class GetCitiesCommand : IResasUiCommand
	{
		#region field

		private readonly IResasRepository _repository;

		#endregion field

		#region property

		public string Name => "resascity";

		public string ShortName => "rc";

		#endregion property

		#region constructor

		public GetCitiesCommand(IResasRepository repository)
		{
			_repository = repository;
		}

		#endregion constructor

		#region method

		public string Invoke(string[] args)
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

		public string Help()
		{
			return "都市データ一覧を取得する";
		}

		#endregion method

	}
}
