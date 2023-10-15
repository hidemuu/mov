using Mov.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Valuables
{
	public sealed class NumericalValue : ValueObjectBase<NumericalValue>
	{
		#region property

		public decimal Value { get; }

		#endregion property

		#region constructor

		public NumericalValue(decimal value)
		{
			Value = value;
		}

		public static NumericalValue Empty = new NumericalValue(0);

		#endregion constructor

		#region inner method

		protected override bool EqualCore(NumericalValue other)
		{
			return Value.Equals(other.Value);
		}

		protected override int GetHashCodeCore()
		{
			return Value.GetHashCode();
		}

		#endregion inner method
	}
}
