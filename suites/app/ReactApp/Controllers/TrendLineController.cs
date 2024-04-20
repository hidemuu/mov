using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Analizer.Service.Regions.Schemas;
using Mov.Analizer.Service;
using Mov.Core.Valuables;
using Mov.Analizer.Service.Regions.Schemas.Contents;

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
			var prefecture = (await _client.GetPrefectureTableLineAsync()).Results.FirstOrDefault(x => x.Id.Equals(prefCode));
			var cities = (await _client.GetCityTableLineAsync(prefCode)).Results;
			var response = await this._client.GetTrendLineAsync(
				new RegionRequestSchema()
				{
					Prefectures = new List<PrefectureSchema>()
					{
						new PrefectureSchema()
						{
							Code = prefCode,
							Name = prefecture?.Name ?? string.Empty,
							Cities = cities.Select(x => new CitySchema()
							{
								Code = x.Id,
								Name = x.Name,
							}).ToList(),
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
			);
			return Ok(response);
		}

		/// <summary>
		/// Gets PopulationPerYears
		/// </summary>
		[HttpGet("population_per_years/{prefCode}/{cityCode}")]
		public async Task<IActionResult> GetPopulationPerYears(int prefCode, int cityCode)
		{
			var prefecture = (await _client.GetPrefectureTableLineAsync()).Results.FirstOrDefault(x => x.Id.Equals(prefCode));
			var city = (await _client.GetCityTableLineAsync(prefCode)).Results.FirstOrDefault(x => x.Id.Equals(cityCode));
			var response = await this._client.GetTrendLineAsync(
				new RegionRequestSchema()
				{
					Prefectures = new List<PrefectureSchema>()
					{
						new PrefectureSchema()
						{
							Code = prefCode,
							Name = prefecture?.Name ?? string.Empty,
							Cities = new List<CitySchema>
							{ 
								new CitySchema() 
									{ 
										Code = cityCode, 
										Name = city?.Name ?? string.Empty, 
									} 
							},
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
			);
			return Ok(response);
		}

		/// <summary>
		/// Gets all items.
		/// </summary>
		[HttpGet("population_per_years/{prefCode}/{cityCode}/{category}/{label}/{start}/{end}")]
		public async Task<IActionResult> Get(int prefCode, int cityCode, string category, string label, string srart, string end)
		{
			var prefecture = (await _client.GetPrefectureTableLineAsync()).Results.FirstOrDefault(x => x.Id.Equals(prefCode));
			var city = (await _client.GetCityTableLineAsync()).Results.FirstOrDefault(x => x.Id.Equals(cityCode));

			return Ok(await this._client.GetTrendLineAsync(
				new RegionRequestSchema()
				{
					Prefectures = new List<PrefectureSchema>()
					{
						new PrefectureSchema()
						{
							Code = prefCode,
							Name = prefecture?.Name ?? string.Empty,
							Cities = new List <CitySchema>
							{
								new CitySchema()
								{
									Code = cityCode,
									Name = city?.Name ?? string.Empty,
								}
							},
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
