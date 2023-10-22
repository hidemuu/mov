using Mov.Analizer.Models.Schemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Entities
{
	public class TableLine : IAnalizeContent
	{
		#region property

		public int Id { get; }
		public string Category { get; }
		public string Label { get; }
		public string Name { get; }
		public string Content { get; }

		#endregion property

		#region constructor

		public TableLine(int id, string category, string label, string name, string content)
		{
			Id = id;
			Category = category;
			Label = label;
			Name = name;
			Content = content;
		}

		public TableLine(TableLineSchema schema)
		{
			Id = schema.Id;
			Category = schema.Category;
			Label = schema.Label;
			Name= schema.Name;
			Content = schema.Content;
		}

		#endregion constructor

		#region method

		public TableLineSchema CreateSchema()
		{
			return new TableLineSchema()
			{
				Id = Id,
				Category = Category,
				Label = Label,
				Name = Name,
				Content = Content
			};
		}

		#endregion method

	}
}
