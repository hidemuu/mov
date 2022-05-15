using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Accessors
{
    public class DbObject
    {

        #region プロパティ

        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id")]
        [XmlElement("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// インデックス番号
        /// </summary>
        [JsonProperty("index")]
        [XmlElement("index")]
        public int Index { get; set; }

        /// <summary>
        /// コード
        /// </summary>
        [JsonProperty("code")]
        [XmlElement("code")]
        public string Code { get; set; }

        #endregion

        #region メソッド

        public override string ToString() => GetString(new string[] { Id.ToString(), Code });

        public virtual string ToStringTableHeader() => GetString(new string[] { "Id", "Code", }, 10);

        public virtual string ToStringTable() => GetString(new string[] { Id.ToString(), Code, }, 10);

        #endregion

        #region 継承メソッド

        protected static string GetString(string[] strings, int padding = 0)
        {
            var stringBuilder = new StringBuilder();
            foreach(var str in strings)
            {
                if (string.IsNullOrEmpty(str)) continue;
                stringBuilder.Append((str + " ").PadRight(padding));
            }
            return stringBuilder.ToString();
        }

        #endregion

    }
}
