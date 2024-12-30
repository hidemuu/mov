using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Repositories
{
	public interface IDbRequestSchema
	{
		#region property

		string Uri { get; }

		#endregion property

		#region method

		bool IsEmpty();

		#endregion method
	}
}
