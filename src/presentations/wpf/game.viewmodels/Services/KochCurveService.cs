using Mov.Game.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Game.ViewModels.Services
{
    public class KochCurveService : CanvasServiceBase
    {
        public void Draw(int n, double len, double angle)
        {
            if(n == 1)
            {
                Forward(len, angle);
            }
            else
            {
                var l = len / (2 / Math.Sqrt(2) + 2);
                var a = Math.PI * 0.25;
                Draw(n - 1, l, angle);
                Draw(n - 1, l, angle - a);
                Draw(n - 1, l, angle + a);
                Draw(n - 1, l, angle);
            }
        }
    }
}
