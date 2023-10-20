using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Repositories.Schemas
{
	public abstract class DbRequestSchemaBase : IDbRequestSchema
	{
		#region property

		public string Uri { get; } = string.Empty;

		#endregion property

		#region constructor

		public DbRequestSchemaBase(IReadOnlyDictionary<string, string> parameters)
		{
			foreach(var parameter in parameters)
			{
				Uri += $"{parameter.Key}={parameter.Value}&";
			}
			Uri = Uri.TrimEnd('&');
		}

		#endregion constructor

		#region method

		public bool IsEmpty() => Uri == string.Empty;

		#endregion method
	}
}
