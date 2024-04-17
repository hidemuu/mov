using CsvHelper.Configuration.Attributes;
using FluentFTP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mov.Core.Repositories.Schemas.Responses
{
	public class DbResponseSchemaBase<TIdentifier, TResult> : DbSchemaBase<TIdentifier> where TResult : IDbResponseSchema
	{
		#region property

		[Name("message")]
		[JsonProperty("message")]
		[DisplayName("メッセージ")]
		public override TIdentifier Id { get; set; }

		[Name("result")]
		[JsonProperty("result")]
		[DisplayName("結果")]
		public List<TResult> Results { get; set; } = new List<TResult>();

		#endregion proeprty
	}
}
