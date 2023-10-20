using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Repositories.Schemas.Requests
{
	public class DbRequestSchemaString : IDbRequestSchema
	{
		#region property

		public string Uri { get; }

		#endregion property

		#region constructor

		public DbRequestSchemaString(string parameter)
		{
			Uri = parameter;
		}

		#endregion constructor

		#region method

		public bool IsEmpty()
		{
			return Uri.Equals(string.Empty);
		}

		#endregion method
	}
}
