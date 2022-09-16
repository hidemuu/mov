using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Models
{
    public interface IStopwatch
    {
        void Start();
        long Stop();
    }
}
