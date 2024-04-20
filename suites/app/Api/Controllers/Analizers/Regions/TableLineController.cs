using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Analizer.Models.Schemas;
using Mov.Analizer.Service;
using Mov.Core.Repositories.Schemas.Responses;

namespace Mov.Suite.Api.Controllers.Analizers.Regions
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/analizers/regions/[controller]")]
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
            var result = await _client.GetTableLineAsync();
            var content = result.Results.Where(x => x.Category.Equals("prefecture"));
			return Ok(new DbResponseSchema<string, TableLineSchema> { Results = content.ToList() });
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet("prefecture/{prefCode}")]
        public async Task<IActionResult> GetPrefecture(int prefCode)
        {
            var result = await _client.GetTableLineAsync();
            var content = result.Results.Where(x => x.Category.Equals("prefecture")).FirstOrDefault(x => x.Id.Equals(prefCode)) ?? new TableLineSchema();
			return Ok(new DbResponseSchema<string, TableLineSchema> { Results = new List<TableLineSchema> { content } });
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet("city")]
        public async Task<IActionResult> GetCities()
        {
            var result = await _client.GetTableLineAsync();
            var content = result.Results.Where(x => x.Category.Equals("city"));
			return Ok(new DbResponseSchema<string, TableLineSchema> { Results = content.ToList() });
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet("city/{prefCode}")]
        public async Task<IActionResult> GetCities(int prefCode)
        {
            var result = await _client.GetTableLineAsync();
            var content = result.Results.Where(x => x.Category.Equals("city")).Where(x => x.Label.Equals(prefCode));
			return Ok(new DbResponseSchema<string, TableLineSchema> { Results = content.ToList() });
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet("city/{cityCode}")]
        public async Task<IActionResult> GetCity(int cityCode)
        {
            var result = await _client.GetTableLineAsync();
            var conent = result.Results.Where(x => x.Category.Equals("city")).FirstOrDefault(x => x.Id.Equals(cityCode)) ?? new TableLineSchema();
			return Ok(new DbResponseSchema<string, TableLineSchema> { Results = new List<TableLineSchema> { conent } });
        }

        #endregion method
    }
}
