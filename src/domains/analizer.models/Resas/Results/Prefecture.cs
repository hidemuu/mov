using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mov.Analizer.Models.Resas
{
    public class Prefecture : IResasResult
    {
        public const string URI = "prefectures";

        [Name("prefCode")]
        [JsonProperty("prefCode")]
        [DisplayName("都道府県コード")]
        public int Code { get; set; }
        [Name("prefName")]
        [JsonProperty("prefName")]
        [DisplayName("都道府県名")]
        public string Name { get; set; }
    }
}
