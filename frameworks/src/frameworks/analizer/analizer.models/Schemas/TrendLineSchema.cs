using Mov.Core.Attributes;
using Mov.Core.Models;
using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Mov.Analizer.Models.Schemas
{
    public class TrendLineSchema : AnalizeContentSchemaBase<string>
	{
		[JsonProperty("number")]
        public decimal Number { get; set; }

		[JsonProperty("value")]
		public decimal Value { get; set; }
    }
}