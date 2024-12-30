using CsvHelper.Configuration.Attributes;
using FluentFTP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mov.Core.Repositories.Schemas.Responses
{
	public class DbResponseSchema<TIdentifier, TResult> : DbSchemaBase<TIdentifier>
	{
		#region property

		[Name("identifier")]
		[JsonProperty("identifier")]
		[DisplayName("ID")]
		public override TIdentifier Id { get; set; }

		[Name("results")]
		[JsonProperty("results")]
		[DisplayName("結果")]
		public List<TResult> Results { get; set; } = new List<TResult>();

		#endregion proeprty
	}
}
