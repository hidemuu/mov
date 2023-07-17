using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Bom.Models.Schemas;
using Mov.Bom.Models;

namespace Mov.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region field

        private readonly IBomRepository repository;

        #endregion field

        #region constructor

        /// <summary>
        /// controller for design contents
        /// </summary>
        /// <param name="repository"></param>
        public ProductController(IBomRepository repository)
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
