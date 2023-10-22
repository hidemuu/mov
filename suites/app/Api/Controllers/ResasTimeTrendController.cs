using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Analizer.Service;
using Mov.Analizer.Service.Regions;
using Mov.Core.Valuables;

namespace Mov.Suite.Api.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class ResasTimeTrendController : ControllerBase
	{
		#region field

		private readonly IRegionAnalizerClient _client;

		#endregion field

		#region constructor

		/// <summary>
		/// 
		/// </summary>
		/// <param name="client"></param>
		public ResasTimeTrendController(IRegionAnalizerClient client)
		{
			_client = client;
		}

		#endregion constructor

		#region method

		/// <summary>
		/// Gets all items.
		/// </summary>
		[HttpGet("{schema}/{start}/{end}")]
		public async Task<IActionResult> Get(RegionRequestSchema schema, string srart, string end)
		{
			return Ok(await this._client.GetTimeTrendAsync(schema, TimeValue.Factory.Create(srart), TimeValue.Factory.Create(end)));
		}

		#endregion method
	}
}
