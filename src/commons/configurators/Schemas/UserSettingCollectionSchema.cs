using Mov.Schemas.EntityObjects.DbObjects;
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
    [XmlRoot("user_settings")]
    public class UserSettingCollectionSchema : DbObjectCollection<UserSettingSchema>
    {
        /// <inheritdoc />
        [JsonProperty("user_settings")]
        [XmlElement(Type = typeof(UserSettingSchema), ElementName = "user_setting")]
        public override UserSettingSchema[] Items { get; set; }
    }
}
