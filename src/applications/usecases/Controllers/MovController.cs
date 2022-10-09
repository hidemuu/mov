using Mov.Configurator.Service;
using Mov.Controllers;
using Mov.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.UseCases.Controllers
{
    public class MovController
    {
        private IMovEngine engine;
        private IDictionary<string, IController> domainControllers = new Dictionary<string, IController>();

        public MovController(IMovEngine engine)
        {
            this.engine = engine;
            CreateDomainControllers();
        }

        private void CreateDomainControllers()
        {
            var factory = new DomainControllerFactory("Commands");
            domainControllers.Add(
                FrameworkConstants.DOMAIN_NAME_CONFIG, 
                factory.Create(this.engine.Service.Configurator));
            
        }
    }
}
