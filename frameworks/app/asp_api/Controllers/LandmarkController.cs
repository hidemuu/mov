using Microsoft.AspNetCore.Mvc;
using Mov.Game.Models;
using Mov.Game.Models.Schemas;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.AspApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LandmarkController : ControllerBase
    {
        #region field

        private readonly IGameRepository repository;

        #endregion field

        #region constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public LandmarkController(IGameRepository repository)
        {
            this.repository = repository;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<LandmarkSchema>> Get()
        {
            return await this.repository.Landmarks.GetAsync();
        }

        
        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LandmarkSchema item)
        {
            await this.repository.Landmarks.PostAsync(item);
            return Ok();
        }

        //[HttpDelete("{date}")]
        //public async Task<IActionResult> Delete(LandmarkSchema item)
        //{
        //    await this.repository.Landmarks.DeleteAsync(item.Date);
        //    return Ok();
        //}

        #endregion method
    }
}
