using System;
using System.Collections.Generic;
using System.Text;

namespace Devices
{
    public interface IStopwatch
    {
        void Start();
        long Stop();
    }
}
