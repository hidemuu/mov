using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions.Schemas
{
    public class RegionRequestSchema
    {
        #region property

        [JsonProperty("pref_code")]
        public List<int> PrefCodes { get; set; } = new List<int>();

        [JsonProperty("city_code")]
        public List<int> CityCodes { get; set; } = new List<int>();

        [JsonProperty("category")]
        public string Category { get; set; } = string.Empty;

        [JsonProperty("label")]
        public string Label { get; set; } = string.Empty;

        #endregion property
    }
}
