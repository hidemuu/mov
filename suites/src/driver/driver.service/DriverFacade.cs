using Mov.Driver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Service
{
    public class DriverFacade : IDriverFacade
    {
        public IDriverRepository Repository { get; }

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DriverFacade(IDriverRepository repository)
        {
            this.Repository = repository;
        }
    }
}
