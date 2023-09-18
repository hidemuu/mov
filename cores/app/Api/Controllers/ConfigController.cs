using Microsoft.AspNetCore.Mvc;
using Mov.Core.Configurators;
using Mov.Core.Configurators.Models.Schemas;

namespace Mov.Core.Api.Controllers
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
        public async Task<IEnumerable<ConfigSchema>> Get()
        {
            return await this._repository.Configs.GetAsync();
        }

        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ConfigSchema schema)
        {
            await this._repository.Configs.PostAsync(schema);
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ConfigSchema schema)
        {
            await this._repository.Configs.DeleteAsync(schema);
            return Ok();
        }

        #endregion method
    }
}
