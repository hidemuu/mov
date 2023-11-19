using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Analizer.Service;

namespace Mov.Suite.ReactApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TableLineController : ControllerBase
	{
		#region field

		private readonly IRegionAnalizerClient _client;

		#endregion field

		#region constructor

		/// <summary>
		/// 
		/// </summary>
		/// <param name="client"></param>
		public TableLineController(IRegionAnalizerClient client)
		{
			_client = client;
		}

		#endregion constructor

		#region method

		/// <summary>
		/// Gets all items.
		/// </summary>
		[HttpGet("prefecture")]
		public async Task<IActionResult> GetPrefectures()
		{
			var result = await this._client.GetTableLineAsync();
			return Ok(result.Where(x => x.Category.Equals("prefecture")));
		}

		/// <summary>
		/// Gets all items.
		/// </summary>
		[HttpGet("prefecture/{prefCode}")]
		public async Task<IActionResult> GetPrefecture(int prefCode)
		{
			var result = await this._client.GetTableLineAsync();
			return Ok(result.Where(x => x.Category.Equals("prefecture")).FirstOrDefault(x => x.Id.Equals(prefCode)));
		}

		/// <summary>
		/// Gets all items.
		/// </summary>
		[HttpGet("city")]
		public async Task<IActionResult> GetCities()
		{
			var result = await this._client.GetTableLineAsync();
			return Ok(result.Where(x => x.Category.Equals("city")));
		}

		/// <summary>
		/// Gets all items.
		/// </summary>
		[HttpGet("city/{prefCode}")]
		public async Task<IActionResult> GetCities(int prefCode)
		{
			var result = await this._client.GetTableLineAsync();
			return Ok(result.Where(x => x.Category.Equals("city")).Where(x => x.Label.Equals(prefCode)));
		}

		/// <summary>
		/// Gets all items.
		/// </summary>
		[HttpGet("city/{cityCode}")]
		public async Task<IActionResult> GetCity(int cityCode)
		{
			var result = await this._client.GetTableLineAsync();
			return Ok(result.Where(x => x.Category.Equals("city")).FirstOrDefault(x => x.Id.Equals(cityCode)));
		}

		#endregion method
	}
}
