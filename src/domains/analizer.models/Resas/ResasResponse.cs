﻿using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mov.Analizer.Models.Resas
{
    public class ResasResponse<TResult> where TResult : IResasResult
    {
        
        [Name("message")]
        [JsonProperty("message")]
        [DisplayName("メッセージ")]
        public string Message { get; set; }
        [Name("result")]
        [JsonProperty("result")]
        [DisplayName("結果")]
        public List<TResult> Results { get; set; } = new List<TResult>();
    }
}