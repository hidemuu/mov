﻿using Microsoft.AspNetCore.Mvc;
using Mov.Core.Configurators.Repositories.Schemas;
using Mov.Core.Configurators;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Mov.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        #region field

        private readonly IConfiguratorRepository repository;

        #endregion field

        #region constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public ConfigController(IConfiguratorRepository repository)
        {
            this.repository = repository;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<ConfigSchema>> Get()
        {
            return await this.repository.Configs.GetAsync();
        }

        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ConfigSchema item)
        {
            await this.repository.Configs.PostAsync(item);
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