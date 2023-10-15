using Mov.Core.Valuables;

namespace Mov.Analizer.Models.Entities
{
    public class TimeTrend : AnalizeContent
    {
        public DateValue TimeStamp { get; }
		public NumericalValue Content { get; }

    }
}
