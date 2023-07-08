using Microsoft.AspNetCore.Mvc;
using Mov.Game.Models;
using Mov.Game.Models.Schemas;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.AspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandmarkController : ControllerBase
    {
        #region field

        private readonly IGameRepository repository;

        #endregion field

        #region constructor

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
        public async Task<IActionResult> Get()
        {
            return Ok((await this.repository.Landmarks.GetAsync()));
        }

        /// <summary>
        /// Gets the with the given date.
        /// </summary>
        [HttpGet("{date}")]
        public async Task<IActionResult> Get(string date)
        {
            if (date == string.Empty)
            {
                return BadRequest();
            }
            var result = await this.repository.Landmarks.GetAsync(date);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
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
