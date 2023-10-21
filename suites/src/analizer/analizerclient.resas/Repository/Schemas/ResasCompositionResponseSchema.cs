using CsvHelper.Configuration.Attributes;
using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mov.Suite.AnalizerClient.Resas.Repository.Schemas
{
    public class ResasCompositionResponseSchema<TResult> : DbSchemaBase<string> where TResult : IResasResultSchema
	{
		#region property

		[Name("message")]
		[JsonProperty("message")]
		[DisplayName("メッセージ")]
		public override string Id { get; set; }

		[Name("result")]
		[JsonProperty("result")]
		[DisplayName("結果")]
		public TResult Result { get; set; }

		#endregion property

		#region method

		public override string ToString()
		{
			return $"{Id} {Result}";
		}

		#endregion method
	}
}
