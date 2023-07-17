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
    public class NodeController : ControllerBase
    {
        #region field

        private readonly IDesignerRepository repository;

        #endregion field

        #region constructor

        /// <summary>
        /// controller for design contents
        /// </summary>
        /// <param name="repository"></param>
        public NodeController(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<NodeSchema>> Get()
        {
            return await this.repository.Nodes.GetAsync();
        }

        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NodeSchema item)
        {
            await this.repository.Nodes.PostAsync(item);
            return Ok();
        }

        #endregion method
    }
}
