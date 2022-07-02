using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Driver.Models
{
    /// <summary>
    /// マクロのコレクション
    /// </summary>
    [XmlRoot("macros")]
    public class MacroCollection : DbObjectCollection<Macro>
    {
        /// <summary>
        /// コレクション
        /// </summary>
        [JsonProperty("macros")]
        [XmlElement(Type = typeof(Macro), ElementName = "macro")]
        public override Macro[] Items { get; set; }
    }

    [XmlRoot("macro")]
    public class Macro : DbObject
    {
    }
}
