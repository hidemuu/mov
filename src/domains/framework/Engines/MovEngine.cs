using Mov.Analizer.Models;
using Mov.Controllers;
using Mov.Designer.Models;
using Mov.Driver.Models;
using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Framework.Controllers
{
    public class MovEngine : IMovEngine
    {
        public int DomainId { get; }
        public IMovService Service { get; }

        public MovEngine(int domainId, IMovService service)
        {
            this.DomainId = domainId;
            this.Service = service;
        }

    }
}
