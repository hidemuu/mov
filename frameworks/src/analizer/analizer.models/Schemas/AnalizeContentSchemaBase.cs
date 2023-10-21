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

		/// <summary>
		/// カテゴリ
		/// </summary>
		[JsonProperty("category")]
		public string Category { get; set; } = string.Empty;

		/// <summary>
		/// ラベル
		/// </summary>
		[JsonProperty("label")]
		public string Label { get; set; } = string.Empty;
	}
}
