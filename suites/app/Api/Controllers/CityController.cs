using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Suite.AnalizerClient.Resas;
using Mov.Suite.AnalizerClient.Resas.Schemas;
using Mov.Suite.AnalizerClient.Resas.Schemas.Results;

namespace Mov.Suite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        #region field

        private readonly IResasRepository _repository;

        #endregion field

        #region constructor

        /// <summary>
        /// controller for configuration
        /// </summary>
        /// <param name="repository"></param>
        public CityController(IResasRepository repository)
        {
            this._repository = repository;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<ResasResponseSchema<CityResultSchema>>> Get()
        {
            return await this._repository.Cities.GetsAsync();
        }

        #endregion method
    }
}
