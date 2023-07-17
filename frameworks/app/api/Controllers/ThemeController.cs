using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Designer.Models.Schemas;
using Mov.Designer.Models;

namespace Mov.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ThemeController : ControllerBase
    {
        #region field

        private readonly IDesignerRepository repository;

        #endregion field

        #region constructor

        /// <summary>
        /// controller for design contents
        /// </summary>
        /// <param name="repository"></param>
        public ThemeController(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<ThemeSchema>> Get()
        {
            return await this.repository.Themes.GetAsync();
        }

        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ThemeSchema item)
        {
            await this.repository.Themes.PostAsync(item);
            return Ok();
        }

        #endregion method
    }
}
