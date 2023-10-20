using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Suite.AnalizerClient.Resas.Controllers.Commands
{
	public class GetPrefecturesCommand : IResasUiCommand
	{
		#region field

		private readonly IResasRepository _repository;

		#endregion field

		#region property

		public string Name => "resaspref";

		public string ShortName => "rp";

		#endregion property

		#region constructor

		public GetPrefecturesCommand(IResasRepository repository)
		{
			_repository = repository;
		}

		#endregion constructor

		#region method

		public string Invoke(string[] args)
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

		public string Help()
		{
			return "都道府県データ一覧を取得する";
		}

		#endregion method
	}
}
