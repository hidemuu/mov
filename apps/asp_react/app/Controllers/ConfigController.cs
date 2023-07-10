using Microsoft.AspNetCore.Mvc;
using Mov.Core.Configurators;
using Mov.Core.Configurators.Repositories.Schemas;
using Mov.Game.Models.Schemas;

namespace Mov.AspReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        #region field

        private readonly IConfiguratorRepository repository;

        #endregion field

        #region constructor

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
        public async Task<IActionResult> Get()
        {
            return Ok((await this.repository.Configs.GetAsync()));
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

        /// <summary>
        /// Deletes an order.
        /// </summary>
        //[HttpDelete("{date}")]
        //public async Task<IActionResult> Delete(LandmarkSchema item)
        //{
        //    await this.repository.Landmarks.DeleteAsync(item.Date);
        //    return Ok();
        //}

        #endregion method
    }
}