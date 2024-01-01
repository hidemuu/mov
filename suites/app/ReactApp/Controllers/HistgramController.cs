using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Analizer.Service;

namespace Mov.Suite.ReactApp.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class HistgramLineController : Controller
	{
		#region field

		private readonly IRegionAnalizerClient _client;

		#endregion field

		#region constructor

		/// <summary>
		/// 
		/// </summary>
		/// <param name="client"></param>
		public HistgramLineController(IRegionAnalizerClient client)
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

		#endregion method
	}
}
