using Mov.Accessors;
using Mov.Framework;
using Mov.Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Scheduler.Repository
{
    public class SchedulerRepository : DomainRepositoryBase, ISchedulerRepository
    {
        public SchedulerRepository(string dir, string extension, string encoding = "utf-8") : base(extension)
        {
           
        }
    }
}
