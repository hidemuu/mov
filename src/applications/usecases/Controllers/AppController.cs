using Mov.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.UseCases.Controllers
{
    public class AppController
    {
        private IMovEngine engine;

        public AppController(IMovEngine engine)
        {
            this.engine = engine;
        }
    }
}
