using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Configurator.Models
{

    [XmlRoot("variables")]
    public class VariableCollection : DbObjectCollection<Variable>
    {
        [JsonProperty("variables")]
        [XmlElement(Type = typeof(Variable), ElementName = "variable")]
        public override Variable[] Items { get; set; }
    }

    [XmlRoot("variable")]
    public class Variable : AppSetting
    {
        #region プロパティ

        /// <summary>
        /// 読出/書込 (R:読出専用 W:書込専用 それ以外:読書可能
        /// </summary>
        [JsonProperty("readwrite")]
        [DisplayName("読み書き")]
        public string RW { get; set; }

        #endregion

    }
}
