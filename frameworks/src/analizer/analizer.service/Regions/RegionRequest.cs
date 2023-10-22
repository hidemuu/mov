using Mov.Analizer.Models;
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

		public static class Factory 
		{
			public static RegionRequest Create(RegionRequestSchema schema)
			{
				return new RegionRequest(schema.PrefCode, schema.CityCode, schema.Category, schema.Label);
			}

			public static RegionRequest Create(string pref, string city, string category, string label, IAnalizerStoreQuery query)
			{
				int prefCode = -1;
				int cityCode = -1;
				var tableLines = query.TableLines.Reader.ReadAll();
				foreach(var tableLine in tableLines)
				{
					if(tableLine.Category.Equals("prefecture") && tableLine.Content.Equals(pref))
					{
						prefCode = tableLine.Id;
					}
					if(tableLine.Category.Equals("city") && tableLine.Content.Equals(city))
					{
						cityCode = tableLine.Id;
					}
					if(prefCode >= 0 && cityCode >= 0)
					{
						break;
					}
				}
				return new RegionRequest(prefCode, cityCode, category, label);
			}
		}


		#endregion constructor

		#region method

		public bool IsEmptyCategory() => Category == string.Empty;

		public bool IsEmptyLabel() => Label == string.Empty;

		public RegionRequestSchema CreateSchema() 
		{
			return new RegionRequestSchema() 
			{
				PrefCode = PrefCode,
				CityCode = CityCode,
				Category = Category,
				Label = Label,
			};
		}

		#endregion method
	}
}
