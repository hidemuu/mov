using Mov.Driver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Service
{
    public class DriverService : IDriverService
    {
        public IDriverRepository Repository { get; }

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DriverService(IDriverRepository repository)
        {
            this.Repository = repository;
        }
    }
}
