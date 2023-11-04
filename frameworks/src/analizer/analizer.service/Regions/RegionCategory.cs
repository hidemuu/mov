using Mov.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions
{
	public sealed class RegionCategory : ValueObjectBase<RegionCategory>
	{
		#region property

		public string Value { get; }

		#endregion property

		#region constructor

		public RegionCategory(string value) 
		{
			this.Value = value;
		}

		public static RegionCategory Empty => new RegionCategory(string.Empty);

		public static RegionCategory City => new RegionCategory("city");

		public static RegionCategory Prefecture => new RegionCategory("prefecture");

		#endregion constructor

		#region method

		public bool IsEmpty() => this.Equals(Empty);

		public bool IsCity() => this.Equals(City);

		public bool IsPrefecture() => this.Equals(Prefecture);

		#endregion method

		#region logic

		protected override bool EqualCore(RegionCategory other)
		{
			return this.Value.Equals(other.Value, StringComparison.Ordinal);
		}

		protected override int GetHashCodeCore()
		{
			return this.Value.GetHashCode();
		}

		#endregion logic
	}
}
