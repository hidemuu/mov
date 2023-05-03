using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Configurator.Models.Schemas
{
    /// <summary>
    /// 設定のコレクション
    /// </summary>
    [XmlRoot("configs")]
    public class UserSettingCollectionSchema : DbObjectCollection<UserSettingSchema>
    {
        /// <inheritdoc />
        [JsonProperty("configs")]
        [XmlElement(Type = typeof(UserSettingSchema), ElementName = "config")]
        public override UserSettingSchema[] Items { get; set; }
    }
}
