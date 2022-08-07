using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Scheduler.Models
{
    public interface ISchedulerDatabase
    {
        IDictionary<string, ISchedulerRepository> Repositories { get; }

        ISchedulerRepository GetRepository(string dirName);
    }
}
