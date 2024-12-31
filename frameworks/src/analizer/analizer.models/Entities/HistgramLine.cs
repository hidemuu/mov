using Mov.Analizer.Models.Schemas;

namespace Mov.Analizer.Models.Entities
{
    public class HistgramLine : IAnalizeContent
    {
		#region property

		public string Category { get; }
		public string Label { get; }

		#endregion property

		#region constructor

		public HistgramLine(string category, string label) 
		{
			this.Category = category;
			this.Label = label;
		}

		#endregion constructor

		#region method

		public HistgramLineSchema CreateSchema()
		{
			return new HistgramLineSchema();
		}

		#endregion method
	}
}
