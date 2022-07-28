using Mov.Accessors;
using Mov.Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Scheduler.Repository
{
    public class SchedulerDatabase : DbObjectDatabaseBase, ISchedulerDatabase
    {
        public SchedulerDatabase(string resourceDir, string extension, string encoding = "utf-8") : base(resourceDir, extension)
        {
           
        }
    }
}
