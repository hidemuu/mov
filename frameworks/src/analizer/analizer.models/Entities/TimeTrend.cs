using Mov.Core.Valuables;

namespace Mov.Analizer.Models.Entities
{
    public class TimeTrend
    {
        public string Name { get; }
		public DateValue TimeStamp { get; }
		public NumericalValue Content { get; }

    }
}
