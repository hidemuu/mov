using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Entities
{
	public class TableLine : IAnalizeContent
	{
		public string Category { get; }
		public string Label { get; }
		public string Code { get; }

		public string Content { get; }
	}
}
