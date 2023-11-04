using Mov.Analizer.Models.Schemas;
using Mov.Core.Valuables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Entities
{
	public class StatisticLine : IAnalizeContent
	{
		#region property

		public string Category { get; }
		public string Label { get; }
		public IEnumerable<NumericalValue> Values { get; }
		
		public NumericalValue Max { get; }

		public NumericalValue Min { get; }

		public NumericalValue Ave { get; }

		#endregion property

		#region constructor

		public StatisticLine(string category, string label, IEnumerable<NumericalValue> values)
		{
			this.Category = category;
			this.Label = label;
			this.Values = values;
		}

		#endregion constructor

		#region method

		public StatisticLineSchema CreateSchema()
		{
			return new StatisticLineSchema();
		}

		#endregion method

	}
}
