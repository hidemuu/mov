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
			if (args.Length != 4) return string.Empty;
			if (!int.TryParse(args[0], out int cityCode)) return string.Empty;
			if (!int.TryParse(args[1], out int prefCode)) return string.Empty;
			if (!int.TryParse(args[2], out int yearRight)) return string.Empty;
			if (!int.TryParse(args[3], out int yearLeft)) return string.Empty;
			var schema = Task.WhenAll(_repository.PopulationPyramids.GetRequestAsync(new PopulationPyramidRequestSchema(cityCode, prefCode, yearRight, yearLeft))).Result[0];
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
			return "指定年間の人口ピラミッドを取得する [cityCode] [prefCode]　[yearright] [yearleft]";
		}

		#endregion method
	}
}
