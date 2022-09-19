using Mov.Accessors;
using Mov.Accessors.Repository.Implement;
using Mov.BaseModel;
using Mov.Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Scheduler.Repository
{
    public class FileSchedulerRepository : FileDomainRepositoryBase, ISchedulerRepository
    {
        public override string RelativePath => "scheduler";

        public FileSchedulerRepository(string endpoint, string fileDir, string extension, string encoding = "utf-8") 
            : base(endpoint, fileDir, extension, encoding)
        {
           
        }
    }
}
