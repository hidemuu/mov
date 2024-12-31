using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.SpreadSheets.Models
{
	public class WorkCell
	{
		#region property

		public int Row { get; set; }

		public int Col { get; set; }

		public object Value { get; set; }

		#endregion property

		#region constructor

		public WorkCell(int row, int col, object value)
		{
			this.Row = row;
			this.Col = col;
			this.Value = value;
		}

		#endregion constructor
	}
}
