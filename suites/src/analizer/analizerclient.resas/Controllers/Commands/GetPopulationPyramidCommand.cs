using Mov.Suite.AnalizerClient.Resas.Repository.Schemas.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Suite.AnalizerClient.Resas.Controllers.Commands
{
	public class GetPopulationPyramidCommand : IResasUiCommand
	{
		#region field

		private readonly IResasRepository _repository;

		#endregion field

		#region property

		public string Name => "resaspoppy";

		public string ShortName => "rpp";

		#endregion property

		#region constructor

		public GetPopulationPyramidCommand(IResasRepository repository)
		{
			_repository = repository;
		}

		#endregion constructor

		#region method

		public string Invoke(string[] args)
		{
			var schema = Task.WhenAll(_repository.PopulationPyramids.GetRequestAsync(new PopulationPyramidRequestSchema(int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]), int.Parse(args[3])))).Result[0];
			var response = $"{schema.Id}{Environment.NewLine}";
			foreach (var result in schema.Results)
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
