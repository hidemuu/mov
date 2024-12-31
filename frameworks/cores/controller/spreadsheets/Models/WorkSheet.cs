using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Core.SpreadSheets.Models
{
	public class WorkSheet
	{
		#region property

		public string Name { get; }

		public List<WorkCell> Cells { get; } = new List<WorkCell>();

		public int FirstRow
		{
			get
			{
				return Cells.Min(x => x.Row);
			}
		}

		public int LastRow
		{
			get
			{
				return Cells.Max(x => x.Row);
			}
		}

		#endregion property

		#region constructor

		public WorkSheet(string name)
		{
			Name = name;	
		}

		#endregion constructor

		#region method

		public void Add(WorkCell cell)
		{
			Cells.Add(cell);
		}

		public List<WorkCell> GetRow(int row)
		{
			return Cells.Where(x => x.Row == row).ToList();
		}

		#endregion method
	}
}
