using Mov.Analizer.Models.Schemas;
using Mov.Core.Valuables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Entities
{
	public class TimeLine : IAnalizeContent
	{
		#region property

		public string Category { get; }
		public string Label { get; }
		public TimeValue StartTime { get; }
		public TimeValue EndTime { get; }

		#endregion property

		#region constructor

		public TimeLine(string category, string label, TimeValue start, TimeValue end)
		{
			Category = category;
			Label = label;
			StartTime = start;
			EndTime = end;
		}

		public TimeLine(TimeLineSchema schema)
		{
			Category = schema.Category;
			Label = schema.Label;
			StartTime = TimeValue.Factory.Create(schema.StartTime);
			EndTime = TimeValue.Factory.Create(schema.EndTime);
		}

		#endregion constructor

		#region method

		public TimeLineSchema CreateSchema() 
		{
			return new TimeLineSchema() 
			{
				Category = Category,
				Label = Label,
				StartTime = StartTime.ToStringDateTime(),
				EndTime = EndTime.ToStringDateTime(),
			};
		}

		#endregion method
	}
}
