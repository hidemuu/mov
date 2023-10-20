using CsvHelper.Configuration.Attributes;
using Mov.Suite.AnalizerClient.Resas.Schemas.Results.Compositions.PopulationPyramids;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mov.Suite.AnalizerClient.Resas.Schemas.Results
{
    public sealed class PopulationPyramidResultSchema : IResasResultSchema
    {
        #region constants

        public const string URI = @"population/composition/pyramid";

        #endregion constants

        #region property

        [JsonProperty("yearLeft")]
        [DisplayName("年度1")]
        public PopulationPyramidYearResultSchema YearLeft { get; set; }

        [JsonProperty("yearRight")]
        [DisplayName("年度2")]
        public PopulationPyramidYearResultSchema YearRight { get; set; }


        #endregion property
    }
}
