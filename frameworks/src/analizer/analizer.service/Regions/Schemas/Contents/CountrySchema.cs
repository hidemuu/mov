using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions.Schemas.Contents
{
    public class CountrySchema : IRegionContentSchema
    {
        [JsonProperty("country_code")]
        public int Code { get; set; }

		[JsonProperty("country_name")]
		public string Name { get; set; }

		[JsonProperty("prefs")]
        public List<PrefectureSchema> Prefs { get; set; } = new List<PrefectureSchema>();
    }
}
