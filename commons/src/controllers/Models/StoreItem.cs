using Mov.Utilities.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Models
{
    public class StoreItem : QueueObject
    {
        /// <summary>
        /// 更新日時
        /// </summary>
        [JsonProperty("upd")]
        public UpdateDate Upd { get; set; }
        /// <summary>
        /// Datastore項目の内部ID
        /// </summary>
        [JsonProperty("itemId")]
        public int ItemId { get; set; }
        /// <summary>
        /// FleetManager：無し　FleetManager以外：AMR名
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }
        /// <summary>
        /// FleetMamager内の項目カテゴリー
        /// </summary>
        [JsonProperty("category")]
        public string Category { get; set; }
        /// <summary>
        /// FleetManager内のDatastoreグループ名
        /// </summary>
        [JsonProperty("groupName")]
        public string GroupName { get; set; }
        /// <summary>
        /// Datastoreグループの説明
        /// </summary>
        [JsonProperty("groupDescr")]
        public string GroupDescr { get; set; }
        /// <summary>
        /// Datastore項目名
        /// </summary>
        [JsonProperty("itemName")]
        public string ItemName { get; set; }
        /// <summary>
        /// Datastore表示名
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        /// <summary>
        /// Datastore項目のデータ型
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
        /// <summary>
        /// Datastore項目の説明
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
