using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Analizer.Service;
using Mov.Analizer.Service.Regions;
using Mov.Analizer.Service.Regions.Schemas;
using Mov.Core.Valuables;

namespace Mov.Suite.Api.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class ResasTrendLineController : ControllerBase
	{
		#region field

		private readonly IRegionAnalizerClient _client;

		#endregion field

		#region constructor

		/// <summary>
		/// 
		/// </summary>
		/// <param name="client"></param>
		public ResasTrendLineController(IRegionAnalizerClient client)
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
			return Ok(await this._client.GetTrendLineAsync(
				new RegionRequestSchema() 
				{
					PrefCode = prefCode, 
					CityCode = cityCode, 
					Category = category, 
					Label = label 
				}, 
				TimeValue.Factory.Create(srart), 
				TimeValue.Factory.Create(end)
			));
		}

		/// <summary>
		/// Gets PopulationPerYears
		/// </summary>
		[HttpGet("{prefCode}/{cityCode}")]
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
