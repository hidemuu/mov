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
		[HttpGet("city")]
		public async Task<IActionResult> GetCities()
		{
			var result = await this._client.GetTableLineAsync();
			return Ok(result.Where(x => x.Category.Equals("city")));
		}

		#endregion method
	}
}
