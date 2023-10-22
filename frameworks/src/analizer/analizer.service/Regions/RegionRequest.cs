using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions
{
	public class RegionRequest
	{
		#region property

		public int PrefCode { get; }

		public int CityCode { get; }

		public string Category { get; } = string.Empty;

		public string Label { get; } = string.Empty;

		#endregion property

		#region constructor

		public RegionRequest(int prefCode, int cityCode, string category, string label)
		{
			PrefCode = prefCode;
			CityCode = cityCode;
			Category = category;
			Label = label;
		}

		#endregion constructor

		#region method

		public bool IsEmptyCategory() => Category == string.Empty;

		public bool IsEmptyLabel() => Label == string.Empty;

		#endregion method
	}
}
