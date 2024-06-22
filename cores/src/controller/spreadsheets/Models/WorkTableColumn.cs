using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.SpreadSheets.Models
{
	public class WorkTableColumn
	{
		#region property

		public string Name { get; set; }

		public Type Type { get; set; }

		#endregion property

		#region constructor

		public WorkTableColumn(string name, Type type)
		{
			Name = name;
			Type = type;
		}

		public static class Factory 
		{
			public static WorkTableColumn CreateString(string name)
			{
				return new WorkTableColumn(name, Type.GetType("System.String"));
			}

			public static WorkTableColumn CreateInt(string name)
			{
				return new WorkTableColumn(name , Type.GetType("System.Int32"));
			}
		}

		#endregion constructor

	}
}
