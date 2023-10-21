using Mov.Core.Attributes;
using Mov.Core.Models;
using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Analizer.Models.Schemas
{
	public abstract class AnalizeContentSchemaBase : DbSchemaBase<int>
	{
		/// <summary>
		/// ID
		/// </summary>
		[JsonProperty("id")]
		[LanguageKey("id")]
		[DisplayName("id")]
		[DisplayIndex(0)]
		public override int Id { get; set; }

		[JsonProperty("category")]
		public string Category { get; set; } = string.Empty;
	}
}
