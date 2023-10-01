using Microsoft.AspNetCore.Mvc;
using Mov.Bom.Models;
using Mov.Bom.Models.Schemas;

namespace Mov.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region field

        private readonly IBomRepository repository;

        #endregion field

        #region constructor

        /// <summary>
        /// controller for design contents
        /// </summary>
        /// <param name="repository"></param>
        public OrderController(IBomRepository repository)
        {
            this.repository = repository;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await this.repository.Orders.GetAsync();
        }

        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order item)
        {
            await this.repository.Orders.UpsertAsync(item);
            return Ok();
        }

        #endregion method
    }
}
