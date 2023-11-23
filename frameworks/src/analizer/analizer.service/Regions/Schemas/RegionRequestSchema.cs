using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions.Schemas
{
    public class RegionRequestSchema
    {
        #region property

        [JsonProperty("prefectures")]
		public List<PrefectureSchema> Prefectures { get; set; } = new List<PrefectureSchema>();

		[JsonProperty("flag")]
		public FlagSchema Flag { get; set; }

        #endregion property
    }
}
