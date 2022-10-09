using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Scheduler.Models
{
    public class ScheduledEvent : SchedulerObject
    {
        public string Source { get; set; }

        public string Title { get; set; }

        public string Remarks { get; set; }

        public string Kind { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
