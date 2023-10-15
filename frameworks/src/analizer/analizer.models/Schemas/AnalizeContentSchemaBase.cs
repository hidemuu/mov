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
	public abstract class AnalizeContentSchemaBase : DbSchemaBase<Guid>
	{
		/// <summary>
		/// ID
		/// </summary>
		[JsonProperty("id")]
		[LanguageKey("id")]
		[DisplayName("id")]
		[DisplayIndex(0)]
		public override Guid Id { get; set; } = Guid.NewGuid();

		[JsonProperty("name")]
		public string Name { get; set; } = string.Empty;

		[JsonProperty("category")]
		public string Category { get; set; } = string.Empty;
	}
}
