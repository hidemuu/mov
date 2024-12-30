using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions.Schemas.Contents
{
    public class CitySchema : IRegionContentSchema
    {
        [JsonProperty("city_code")]
        public int Code { get; set; }

        [JsonProperty("city_name")]
        public string Name { get; set; }

    }
}
