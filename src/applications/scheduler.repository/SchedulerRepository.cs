using Mov.Accessors;
using Mov.Accessors.Repository.Implement;
using Mov.BaseModel;
using Mov.Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Scheduler.Repository
{
    public class SchedulerRepository : FileDomainRepositoryBase, ISchedulerRepository
    {
        public SchedulerRepository(string dir, string extension, string encoding = "utf-8") : base(dir, extension, encoding)
        {
           
        }
    }
}
