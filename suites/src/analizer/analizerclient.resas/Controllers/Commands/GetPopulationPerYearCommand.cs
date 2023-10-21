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
			if (args.Length != 2) return string.Empty;
			if (!int.TryParse(args[0], out int cityCode)) return string.Empty;
			if (!int.TryParse(args[1], out int prefCode)) return string.Empty;
			var schema = Task.WhenAll(_repository.PopulationPerYears.GetRequestAsync(new PopulationPerYearRequestSchema(cityCode, prefCode))).Result[0];
			Console.WriteLine(schema);
			return schema.ToString();
		}

		public string Help()
		{
			return "年間の人口データを取得する [cityCode] [prefCode]";
		}

		#endregion method
	}
}
