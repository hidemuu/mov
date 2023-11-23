using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions.Schemas
{
	public class CitySchema
	{
		[JsonProperty("city_code")]
		public int CityCode { get; set; }
	}
}
