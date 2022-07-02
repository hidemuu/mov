using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Driver.Models
{
    /// <summary>
    /// エラーのコレクション
    /// </summary>
    [XmlRoot("errors")]
    public class ErrorCollection : DbObjectCollection<Error>
    {
        /// <summary>
        /// コレクション
        /// </summary>
        [JsonProperty("errors")]
        [XmlElement(Type = typeof(Error), ElementName = "error")]
        public override Error[] Items { get; set; }
    }

    [XmlRoot("error")]
    public class Error : DbObject
    {
    }
}
