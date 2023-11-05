using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Analizer.Service.Regions.Schemas;
using Mov.Analizer.Service;
using Mov.Core.Valuables;

namespace Mov.Suite.ReactApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TrendLineController : ControllerBase
	{
		#region field

		private readonly IRegionAnalizerClient _client;

		#endregion field

		#region constructor

		/// <summary>
		/// 
		/// </summary>
		/// <param name="client"></param>
		public TrendLineController(IRegionAnalizerClient client)
		{
			_client = client;
		}

		#endregion constructor

		#region method

		/// <summary>
		/// Gets PopulationPerYears
		/// </summary>
		[HttpGet("population_per_years/{prefCode}/{cityCode}")]
		public async Task<IActionResult> GetPopulationPerYears(int prefCode, int cityCode)
		{
			return Ok(await this._client.GetTrendLineAsync(
				new RegionRequestSchema()
				{
					PrefCode = prefCode,
					CityCode = cityCode,
					Category = "population_per_years",
					Label = "all"
				},
				TimeValue.Empty,
				TimeValue.Empty
			));
		}

		#endregion method
	}
}
