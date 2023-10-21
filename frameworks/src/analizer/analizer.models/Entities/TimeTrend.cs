using Mov.Core.Valuables;

namespace Mov.Analizer.Models.Entities
{
    public class TimeTrend : AnalizeContent
    {
        public TimeValue TimeStamp { get; }
		public NumericalValue Content { get; }

    }
}
