using Microsoft.AspNetCore.Mvc;
using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;

namespace Mov.Api.Controllers
{
    /// <summary>
    /// controller for design contents
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        #region field

        private readonly IDesignerRepository repository;

        #endregion field

        #region constructor

        /// <summary>
        /// controller for design contents
        /// </summary>
        /// <param name="repository"></param>
        public ContentController(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<ContentSchema>> Get()
        {
            return await this.repository.Contents.GetAsync();
        }

        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContentSchema item)
        {
            await this.repository.Contents.PostAsync(item);
            return Ok();
        }

        #endregion method
    }
}
