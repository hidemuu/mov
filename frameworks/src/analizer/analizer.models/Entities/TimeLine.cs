using Mov.Core.Valuables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Entities
{
	public class TimeLine
	{
		public string Name { get; }
		public DateValue StartTime { get; }
		public DateValue EndTime { get; }
	}
}
