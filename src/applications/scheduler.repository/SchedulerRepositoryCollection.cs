using Mov.Accessors.Repository;
using Mov.Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Scheduler.Repository
{
    public class SchedulerRepositoryCollection : FileRepositoryCollectionBase, ISchedulerRepositoryCollection
    {
        public SchedulerRepositoryCollection(string resourceDir, string extension, string encoding = "utf-8") : base(resourceDir, extension)
        {
           
        }
    }
}
