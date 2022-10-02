using Mov.Bom.Models;
using Mov.Controllers.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Bom.Service
{
    public class BomService : RepositoryCommandService<IBomRepository>
    {
        /// <summary>
        /// コンストラクター
        /// </summary>
        public BomService(IBomRepository repository) : base(repository, new BomCommandFactory())
        {
        }
    }
}
