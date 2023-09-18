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
        public async Task<IEnumerable<TranslateSchema>> Get()
        {
            return await this._repository.Translates.GetAsync();
        }

        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TranslateSchema schema)
        {
            await this._repository.Translates.PostAsync(schema);
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] TranslateSchema schema)
        {
            await this._repository.Translates.DeleteAsync(schema);
            return Ok();
        }

        #endregion method
    }
}
