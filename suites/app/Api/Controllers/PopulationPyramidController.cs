﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Suite.AnalizerClient.Resas.Schemas.Results;
using Mov.Suite.AnalizerClient.Resas.Schemas;
using Mov.Suite.AnalizerClient.Resas;

namespace Mov.Suite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulationPyramidController : ControllerBase
    {
        #region field

        private readonly IResasRepository _repository;

        #endregion field

        #region constructor

        /// <summary>
        /// controller for configuration
        /// </summary>
        /// <param name="repository"></param>
        public PopulationPyramidController(IResasRepository repository)
        {
            this._repository = repository;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<ResasResponseSchema<PopulationPyramidResultSchema>>> Get()
        {
            return await this._repository.PopulationPyramids.GetsAsync();
        }

        #endregion method
    }
}