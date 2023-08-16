using Microsoft.AspNetCore.Http;
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

        private readonly IConfiguratorRepository repository;

        #endregion field

        #region constructor

        /// <summary>
        /// controller for configuration
        /// </summary>
        /// <param name="repository"></param>
        public ConfigController(IConfiguratorRepository repository)
        {
            this.repository = repository;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<ConfigSchema>> Get()
        {
            return await this.repository.Configs.GetAsync();
        }

        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ConfigSchema item)
        {
            await this.repository.Configs.PostAsync(item);
            return Ok();
        }

        //[HttpDelete]
        //public async Task<IActionResult> Delete(ConfigSchema item)
        //{
        //    //await this.repository.Configs.DeleteAsync(item);
        //    return Ok();
        //}

        #endregion method
    }
}
