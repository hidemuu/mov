﻿using CsvHelper.Configuration.Attributes;
using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Mov.Suite.AnalizerClient.Resas.Repository.Schemas
{
    public class ResasResponseSchema<TResult> : DbSchemaBase<string> where TResult : IResasResultSchema
    {
		#region property

		[Name("message")]
        [JsonProperty("message")]
        [DisplayName("メッセージ")]
        public override string Id { get; set; }

        [Name("result")]
        [JsonProperty("result")]
        [DisplayName("結果")]
        public List<TResult> Results { get; set; } = new List<TResult>();

		#endregion proeprty

		#region method

		public override string ToString()
		{
			var response = Id;
			foreach (var result in Results)
			{
				response += $"{result}{Environment.NewLine}";
			}
			return response;
		}

		#endregion method
	}
}