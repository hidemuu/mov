using Mov.Analizer.Models.Schemas;
using Mov.Core.Valuables;
using System;

namespace Mov.Analizer.Models.Entities
{
    public class TimeTrend : IAnalizeContent
    {
		#region property

		public string Category { get; }
		public string Label { get; }
		public TimeValue TimeStamp { get; }
		public NumericalValue Value { get; }

		#endregion property

		#region constructor

		public TimeTrend(string category, string label, TimeValue timeStamp, NumericalValue value) 
		{ 
			Category = category;
			Label = label;
			TimeStamp = timeStamp;
			Value = value;
		}

		public TimeTrend(TimeTrendSchema schema)
		{
			Category = schema.Category;
			Label = schema.Label;
			TimeStamp = TimeValue.Factory.Create(schema.TimeStamp);
			Value = new NumericalValue(schema.Value);
		}

		#endregion constructor

		#region method

		public TimeTrendSchema CreateSchema()
		{
			return new TimeTrendSchema()
			{
				Id = $"{Category}_{Label}_{TimeStamp.ToStringDateTime()}",
				Category = Category,
				Label = Label,
				TimeStamp = TimeStamp.ToStringDateTime(),
				Value = Value.Value,
			};
		}

		#endregion method
	}
}
