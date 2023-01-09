using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.DesignPatterns.Structuals.Decorators.Reports
{
    public class ReportingService : IReportingService
    {
        public void Report()
        {
            Console.WriteLine("Here is your report");
        }
    }
}
