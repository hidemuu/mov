using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mov.Suite.AnalizerClient.Resas.Repository.Schemas.Requests;

namespace Mov.Suite.AnalizerClient.Resas.Controllers.Commands
{
	public class GetPopulationPerYearCommand : IResasUiCommand
	{
		#region field

		private readonly IResasRepository _repository;

		#endregion field

		#region property

		public string Name => "resaspopyear";

		public string ShortName => "rpy";

		#endregion property

		#region constructor

		public GetPopulationPerYearCommand(IResasRepository repository)
		{
			_repository = repository;
		}

		#endregion constructor

		#region method

		public string Invoke(string[] args)
		{
			var city = Task.WhenAll(_repository.PopulationPerYears.GetRequestAsync(new PopulationPerYearRequestSchema(int.Parse(args[0]), int.Parse(args[1])))).Result[0];
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
			return "年間の人口データを取得する [cityCode] [prefCode]";
		}

		#endregion method
	}
}
