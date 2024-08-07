﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Suite.AnalizerClient.Resas;
using Mov.Suite.AnalizerClient.Resas.Repository.Schemas.Requests;

namespace Mov.Suite.Api.Controllers.Analizers.Regions.Resas
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/analizers/regions/resas/[controller]")]
    [ApiController]
    public class ResasPopulationPyramidController : ControllerBase
    {
        #region field

        private readonly IResasRepository _repository;

        #endregion field

        #region constructor

        /// <summary>
        /// controller for configuration
        /// </summary>
        /// <param name="repository"></param>
        public ResasPopulationPyramidController(IResasRepository repository)
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
            return Ok(await _repository.PopulationPyramids.GetRequestAsync(new PopulationPyramidRequestSchema(11362, 11, 1980, 2030)));
        }

        #endregion method
    }
}
