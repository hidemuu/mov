using System;

namespace Mov.Calendars
{
    public class Schedule
    {
        public string Id { get; set; }

        public string Source { get; set; }

        public string Title { get; set; }

        public string Remarks { get; set; }

        public string Kind { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
