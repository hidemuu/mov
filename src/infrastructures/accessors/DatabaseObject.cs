using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Accessors
{
    public class DatabaseObject
    {
        #region 定数

        public const string SPACE = " ";

        public const char DELIMITER = ',';

        #endregion

        #region プロパティ

        [JsonProperty("id")]
        [XmlElement("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        [XmlElement("code")]
        public string Code { get; set; }

        #endregion

        #region メソッド

        public override string ToString() => GetString(new string[] { Id.ToString(), Code });

        #endregion

        #region 継承メソッド

        protected string GetString(string[] strings)
        {
            var stringBuilder = new StringBuilder();
            foreach(var str in strings)
            {
                stringBuilder.Append(str).Append(DatabaseObject.SPACE);
            }
            return stringBuilder.ToString();
        }

        #endregion

    }
}
