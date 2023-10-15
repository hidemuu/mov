using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Suite.AnalizerClient.Resas.Schemas.Results;
using Mov.Suite.AnalizerClient.Resas.Schemas;
using Mov.Suite.AnalizerClient.Resas;

namespace Mov.Suite.ReactApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrefectureController : ControllerBase
    {
        #region field

        private readonly IResasRepository _repository;

        #endregion field

        #region constructor

        /// <summary>
        /// controller for configuration
        /// </summary>
        /// <param name="repository"></param>
        public PrefectureController(IResasRepository repository)
        {
            this._repository = repository;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await this._repository.Prefectures.GetAsync(null);
            return Ok(response);
        }

        #endregion method
    }
}
