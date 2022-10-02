using Mov.Controllers.Service;
using Mov.Driver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Service
{
    public class DriverService : RepositoryCommandService<IDriverRepository>
    {
        /// <summary>
        /// コンストラクター
        /// </summary>
        public DriverService(IDriverRepository repository) : base(repository, new DriverCommandFactory())
        {
        }
    }
}
