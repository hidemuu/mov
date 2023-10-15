using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Suite.AnalizerClient.Resas.Schemas.Results;
using Mov.Suite.AnalizerClient.Resas.Schemas;
using Mov.Suite.AnalizerClient.Resas;

namespace Mov.Suite.ReactApp.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IEnumerable<ResasResponseSchema<PrefectureResultSchema>>> Get()
        {
            return await this._repository.Prefectures.GetsAsync();
        }

        #endregion method
    }
}
