using Mov.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Accessors.Models
{
	public sealed class RequestHeaderSchema : ValueObjectBase<RequestHeaderSchema>
	{
		#region property

		public IReadOnlyDictionary<string, string> Parameters { get; }

		#endregion property

		#region constructor

		public RequestHeaderSchema(IReadOnlyDictionary<string, string> parameters) 
		{
			Parameters = parameters;
		}

		public static RequestHeaderSchema Empty { get; } = new RequestHeaderSchema(new Dictionary<string, string>());

		#endregion constructor

		#region method

		protected override bool EqualCore(RequestHeaderSchema other)
		{
			return Parameters.Equals(other.Parameters);
		}

		protected override int GetHashCodeCore()
		{
			return Parameters.GetHashCode();
		}

		#endregion method
	}
}
