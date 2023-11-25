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
		[HttpGet("population_per_years/{prefCode}")]
		public async Task<IActionResult> GetPopulationPerYears(int prefCode)
		{
			var tableLines = await this._client.GetTableLineAsync();
			var cities = tableLines.Where(x => x.Category.Equals("city"));
			var prefCities = cities.Where(x => x.Label.Equals(prefCode.ToString())).ToList();
			return Ok(await this._client.GetTrendLineAsync(
				new RegionRequestSchema()
				{
					Prefectures = new List<PrefectureSchema>()
					{
						new PrefectureSchema()
						{
							PrefCode= prefCode,
							CityCodes = prefCities.Select(x => x.Id).ToList(),
						}
					},
					Flag = new FlagSchema()
					{
						Category = "population_per_years",
						Label = "all"
					},
				},
				TimeValue.Empty,
				TimeValue.Empty
			));
		}

		/// <summary>
		/// Gets PopulationPerYears
		/// </summary>
		[HttpGet("population_per_years/{prefCode}/{cityCode}")]
		public async Task<IActionResult> GetPopulationPerYears(int prefCode, int cityCode)
		{
			return Ok(await this._client.GetTrendLineAsync(
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
						Category = "population_per_years",
						Label = "all"
					},
				},
				TimeValue.Empty,
				TimeValue.Empty
			));
		}

		#endregion method
	}
}
