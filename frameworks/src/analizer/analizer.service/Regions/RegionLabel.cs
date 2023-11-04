using Mov.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions
{
	public sealed class RegionLabel : ValueObjectBase<RegionLabel>
	{
		#region property

		public string Value { get; }

		#endregion property

		#region constructor

		public RegionLabel(string value) 
		{
			this.Value = value;
		}

		public static RegionLabel Empty => new RegionLabel(string.Empty);

		public static RegionLabel All => new RegionLabel("all");

		public static RegionLabel Young => new RegionLabel("young");

		public static RegionLabel Senior => new RegionLabel("senior");

		public static RegionLabel Old => new RegionLabel("old");

		#endregion constructor

		#region method

		public bool IsEmpty() => this.Equals(Empty);

		public bool IsAll() => this.Equals(All);

		public bool IsYoung() => this.Equals(Young);

		public bool IsSenior() => this.Equals(Senior);

		public bool IsOld() => this.Equals(Old);

		#endregion method

		#region logic

		protected override bool EqualCore(RegionLabel other)
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
