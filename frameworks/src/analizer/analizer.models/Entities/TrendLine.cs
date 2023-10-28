using Mov.Analizer.Models.Schemas;
using Mov.Core.Valuables;
using System;

namespace Mov.Analizer.Models.Entities
{
    public class TrendLine : IAnalizeContent
    {
		#region property

		public string Category { get; }
		public string Label { get; }
		public NumericalValue Number { get; }
		public NumericalValue Value { get; }

		#endregion property

		#region constructor

		public TrendLine(string category, string label, NumericalValue number, NumericalValue value) 
		{ 
			Category = category;
			Label = label;
			Number = number;
			Value = value;
		}

		public TrendLine(TrendLineSchema schema)
		{
			Category = schema.Category;
			Label = schema.Label;
			Number = new NumericalValue(schema.Number);
			Value = new NumericalValue(schema.Value);
		}

		#endregion constructor

		#region method

		public TrendLineSchema CreateSchema()
		{
			return new TrendLineSchema()
			{
				Id = $"{Category}_{Label}_{Number}",
				Category = Category,
				Label = Label,
				Number = Number.Value,
				Value = Value.Value,
			};
		}

		#endregion method
	}
}
