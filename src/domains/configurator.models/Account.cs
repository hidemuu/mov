﻿using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Configurator.Models
{
    /// <summary>
    /// アカウントリスト
    /// </summary>
    public class AccountCollection : DbObjectCollection<Account>
    {
        [JsonProperty("accounts")]
        public override Account[] Items { get; set; }
    }

    /// <summary>
    /// アカウント
    /// </summary>
    [XmlRoot("account")]
    public class Account : DbObject
    {
        [JsonProperty("loginid")]
        [XmlElement("loginid")]
        public string LoginId { get; set; }
        [JsonProperty("password")]
        [XmlElement("password")]
        public string Password { get; set; }
    }
}