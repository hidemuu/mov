using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Suite.AnalizerClient.Resas;

namespace Mov.Suite.Api.Controllers.Analizers.Regions.Resas
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/analizers/regions/resas/[controller]")]
    [ApiController]
    public class ResasCityController : ControllerBase
    {
        #region field

        private readonly IResasRepository _repository;

        #endregion field

        #region constructor

        /// <summary>
        /// controller for configuration
        /// </summary>
        /// <param name="repository"></param>
        public ResasCityController(IResasRepository repository)
        {
            _repository = repository;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.Cities.GetAsync(null));
        }

        #endregion method
    }
}
