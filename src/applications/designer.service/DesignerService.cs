using Mov.Controllers.Service;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service
{
    public class DesignerService : RepositoryCommandService<IDesignerRepository>, IDesignerService
    {
        /// <summary>
        /// コンストラクター
        /// </summary>
        public DesignerService(IDesignerRepository repository) : base(repository, new DesignerCommandFactory())
        {
        }
    }
}
