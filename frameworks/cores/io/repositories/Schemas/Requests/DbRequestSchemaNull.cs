using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Repositories.Schemas.Requests
{
	public class DbRequestSchemaNull : IDbRequestSchema
	{
		public string Uri { get; } = string.Empty;

		public bool IsEmpty()
		{
			return true;
		}
	}
}
