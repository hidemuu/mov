using Microsoft.AspNetCore.Mvc;
using Mov.Core.Configurators;
using Mov.Core.Configurators.Models.Schemas;

namespace Mov.Api.Controllers
{
    /// <summary>
    /// controller for configuration
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        #region field

        private readonly IConfiguratorRepository _repository;

        #endregion field

        #region constructor

        /// <summary>
        /// controller for configuration
        /// </summary>
        /// <param name="repository"></param>
        public ConfigController(IConfiguratorRepository repository)
        {
            this._repository = repository;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<UserSettingSchema>> Get()
        {
            return await this._repository.UserSettings.GetsAsync();
        }

        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserSettingSchema schema)
        {
            var response = await this._repository.UserSettings.PostAsync(schema);
            if (response.IsSuccess()) return Ok();
            return BadRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] UserSettingSchema schema)
        {
            var response = await this._repository.UserSettings.DeleteAsync(schema);
            if (response.IsSuccess()) return Ok();
            return BadRequest();
        }

        #endregion method
    }
}

