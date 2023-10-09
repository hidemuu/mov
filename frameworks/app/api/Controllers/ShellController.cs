using Microsoft.AspNetCore.Mvc;
using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;

namespace Mov.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ShellController : ControllerBase
    {
        #region field

        private readonly IDesignerRepository repository;

        #endregion field

        #region constructor

        /// <summary>
        /// controller for design contents
        /// </summary>
        /// <param name="repository"></param>
        public ShellController(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<ShellSchema>> Get()
        {
            return await this.repository.Shells.GetsAsync();
        }

        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShellSchema item)
        {
            await this.repository.Shells.PostAsync(item);
            return Ok();
        }

        #endregion method
    }
}
