using Mov.Accessors;
using Mov.Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Scheduler.Repository
{
    public class SchedulerDatabase : DbObjectDatabaseBase<ISchedulerRepository, SchedulerRepository>, ISchedulerDatabase
    {
        public SchedulerDatabase(string dir, string extension, string encode = SerializeConstants.ENCODE_NAME_UTF8) : base(dir, extension, encode)
        {

        }
    }
}
