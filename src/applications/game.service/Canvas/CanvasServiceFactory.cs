using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Service.Canvas
{
    public class CanvasServiceFactory
    {

        public CanvasServiceBase Create(string code)
        {
            return Activator.CreateInstance<CanvasServiceBase>();
        }
    }
}
