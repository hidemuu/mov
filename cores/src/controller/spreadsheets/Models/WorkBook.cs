using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.SpreadSheets.Models
{
	public class WorkBook
	{
		#region property

		public string Name { get; set; }

		public List<WorkSheet> Sheets { get; set; } = new List<WorkSheet>();

		#endregion property

		#region constructor

		public WorkBook(string name)
		{
			Name = name;	
		}

		#endregion constructor

		#region method

		public void Add(WorkSheet sheet)
		{
			Sheets.Add(sheet);
		}

		#endregion method
	}
}
