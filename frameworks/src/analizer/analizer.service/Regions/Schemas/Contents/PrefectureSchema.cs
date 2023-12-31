using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions.Schemas.Contents
{
    public class PrefectureSchema : IRegionContentSchema
    {
        [JsonProperty("pref_code")]
        public int Code { get; set; }

        [JsonProperty("pref_name")]
        public string Name { get; set; }

        [JsonProperty("cities")]
        public List<CitySchema> Cities { get; set; } = new List<CitySchema>();
    }
}
