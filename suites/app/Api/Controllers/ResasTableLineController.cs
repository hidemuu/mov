using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Analizer.Service;
using Mov.Suite.AnalizerClient.Resas;

namespace Mov.Suite.Api.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class ResasTableLineController : ControllerBase
	{
		#region field

		private readonly IRegionAnalizerClient _client;

		#endregion field

		#region constructor

		/// <summary>
		/// 
		/// </summary>
		/// <param name="client"></param>
		public ResasTableLineController(IRegionAnalizerClient client)
		{
			_client = client;
		}

		#endregion constructor

		#region method

		/// <summary>
		/// Gets all items.
		/// </summary>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await this._client.GetTableLineAsync());
		}

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
