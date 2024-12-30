using Microsoft.AspNetCore.Mvc;
using Mov.Core.Translators;
using Mov.Core.Translators.Models.Schemas;

namespace Mov.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TranslateController : ControllerBase
    {
        #region field

        private readonly ITranslatorRepository _repository;

        #endregion field

        #region constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public TranslateController(ITranslatorRepository repository)
        {
            this._repository = repository;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<LocalizeSchema>> Get()
        {
            return await this._repository.Localizes.GetsAsync();
        }

        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LocalizeSchema schema)
        {
            var response = await this._repository.Localizes.PostAsync(schema);
            if (response.IsSuccess()) return Ok();
            return BadRequest();
        }

        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] LocalizeSchema schema)
        {
            var response = await this._repository.Localizes.PutAsync(schema);
            if (response.IsSuccess()) return Ok();
            return BadRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] LocalizeSchema schema)
        {
            var response = await this._repository.Localizes.DeleteAsync(schema);
            if (response.IsSuccess()) return Ok();
            return BadRequest();
        }

        #endregion method
    }
}
