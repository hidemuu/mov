using Mov.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Accessors.Models
{
	public sealed class RequestHeaderSchema : ValueObjectBase<RequestHeaderSchema>
	{
		#region property

		public IReadOnlyDictionary<string, string> Headers { get; }

		#endregion property

		#region constructor

		public RequestHeaderSchema(IReadOnlyDictionary<string, string> headers) 
		{
			Headers = headers;
		}

		#endregion constructor

		#region method

		protected override bool EqualCore(RequestHeaderSchema other)
		{
			throw new NotImplementedException();
		}

		protected override int GetHashCodeCore()
		{
			throw new NotImplementedException();
		}

		#endregion method
	}
}
