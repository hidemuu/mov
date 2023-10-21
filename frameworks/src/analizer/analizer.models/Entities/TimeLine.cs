using Mov.Core.Valuables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Entities
{
	public class TimeLine : AnalizeContent
	{
		public TimeValue StartTime { get; }
		public TimeValue EndTime { get; }
	}
}
