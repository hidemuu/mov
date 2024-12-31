using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.SpreadSheets.Models
{
	public class WorkTable
	{
		#region property

		public List<WorkTableColumn> Columns { get; }

		#endregion property

		#region contructor

		public WorkTable(List<WorkTableColumn> columns)
		{
			Columns = columns;
		}

		#endregion constructor

		#region method

		#endregion method
	}
}
