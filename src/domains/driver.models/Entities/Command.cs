﻿using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Driver.Models
{
    /// <summary>
    /// コマンドのコレクション
    /// </summary>
    [XmlRoot("commands")]
    public class CommandCollection : DbObjectCollection<Command>
    {
        /// <inheritdoc />
        [JsonProperty("commands")]
        [XmlElement(Type = typeof(Command), ElementName = "command")]
        public override Command[] Items { get; set; }
    }

    /// <summary>
    /// コマンド
    /// </summary>
    [XmlRoot("command")]
    public class Command : DbObject
    {
    }
}