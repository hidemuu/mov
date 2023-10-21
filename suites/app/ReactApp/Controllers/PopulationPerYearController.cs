using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Suite.AnalizerClient.Resas;
using Mov.Suite.AnalizerClient.Resas.Repository.Schemas.Results;
using Mov.Suite.AnalizerClient.Resas.Repository.Schemas;

namespace Mov.Suite.ReactApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulationPerYearController : ControllerBase
    {
        #region field

        private readonly IResasRepository _repository;

        #endregion field

        #region constructor

        /// <summary>
        /// controller for configuration
        /// </summary>
        /// <param name="repository"></param>
        public PopulationPerYearController(IResasRepository repository)
        {
            this._repository = repository;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<ResasCompositionResponseSchema<PopulationPerYearResultSchema>>> Get()
        {
            return await this._repository.PopulationPerYears.GetsAsync();
        }

        #endregion method
    }
}
