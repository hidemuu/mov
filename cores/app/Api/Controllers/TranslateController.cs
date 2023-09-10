using Microsoft.AspNetCore.Mvc;
using Mov.Core.Translators;
using Mov.Core.Translators.Models.Schemas;

namespace Mov.Core.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TranslateController : ControllerBase
    {
        #region field

        private readonly ITranslatorRepository repository;

        #endregion field

        #region constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public TranslateController(ITranslatorRepository repository)
        {
            this.repository = repository;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<TranslateSchema>> Get()
        {
            return await this.repository.Translates.GetAsync();
        }

        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TranslateSchema item)
        {
            await this.repository.Translates.PostAsync(item);
            return Ok();
        }

        //[HttpDelete]
        //public async Task<IActionResult> Delete(ConfigSchema item)
        //{
        //    //await this.repository.Configs.DeleteAsync(item);
        //    return Ok();
        //}

        #endregion method
    }
}
