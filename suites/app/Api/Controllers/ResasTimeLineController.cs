using Microsoft.AspNetCore.Mvc;
using Mov.Analizer.Service.Regions;
using Mov.Analizer.Service;
using Mov.Core.Valuables;
using Mov.Analizer.Service.Regions.Schemas;

namespace Mov.Suite.Api.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class ResasTimeLineController : Controller
	{
		#region field

		private readonly IRegionAnalizerClient _client;

		#endregion field

		#region constructor

		/// <summary>
		/// 
		/// </summary>
		/// <param name="client"></param>
		public ResasTimeLineController(IRegionAnalizerClient client)
		{
			_client = client;
		}

		#endregion constructor

		#region method

		/// <summary>
		/// Gets all items.
		/// </summary>
		[HttpGet("{prefCode}/{cityCode}/{category}/{label}/{start}/{end}")]
		public async Task<IActionResult> Get(int prefCode, int cityCode, string category, string label, string srart, string end)
		{
			return Ok(await this._client.GetTimeLineAsync(
				new RegionRequestSchema()
				{
					Prefectures = new List<PrefectureSchema>()
					{
						new PrefectureSchema()
						{
							PrefCode= prefCode,
							CityCodes = new List<int>{ cityCode },
						}
					},
					Flag = new FlagSchema() 
					{
						Category = category,
						Label = label
					},
				},
				TimeValue.Factory.Create(srart),
				TimeValue.Factory.Create(end)
			));
		}

		#endregion method
	}
}
