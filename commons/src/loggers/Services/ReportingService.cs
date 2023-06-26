using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Loggers.Services
{
    public class ReportingService : IReportingService
    {
        public void Report()
        {
            Console.WriteLine("Here is your report");
        }
    }
}
