using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Job
{
    public enum CommandStatus
    {
        Nothing = 0,
        Posted = 1,
        Registered = 2,
        Finished = 3,
        Canceled = 4,
    }
}
