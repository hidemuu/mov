using Microsoft.AspNetCore.Mvc;
using Mov.Bom.Models;
using Mov.Bom.Models.Schemas;
using Mov.Framework;

namespace Mov.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BomProductController : ControllerBase
    {
        #region field

        private readonly IBomRepository repository;

        #endregion field

        #region constructor

        /// <summary>
        /// controller for design contents
        /// </summary>
        /// <param name="repository"></param>
        public BomProductController(IBomRepository repository)
        {
            this.repository = repository;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await this.repository.Products.GetAsync();
        }

        #endregion method
    }
}
