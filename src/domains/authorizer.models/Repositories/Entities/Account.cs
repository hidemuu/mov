using Mov.Accessors;
using Mov.Utilities.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Authorizer.Models
{
    /// <summary>
    /// アカウントリスト
    /// </summary>
    public class AccountCollection : DbObjectCollection<Account>
    {
        /// <inheritdoc />
        [JsonProperty("accounts")]
        public override Account[] Items { get; set; }
    }

    /// <summary>
    /// アカウント
    /// </summary>
    [XmlRoot("account")]
    public class Account : DbObject
    {
        /// <summary>
        /// ログインID
        /// </summary>
        [JsonProperty("loginid")]
        [XmlElement("loginid")]
        [LanguageKey("loginid")]
        [DisplayName("loginid")]
        [DisplayIndex(10)]
        public string LoginId { get; set; }
        /// <summary>
        /// パスワード
        /// </summary>
        [JsonProperty("password")]
        [XmlElement("password")]
        [LanguageKey("password")]
        [DisplayName("password")]
        [DisplayIndex(11)]
        public string Password { get; set; }

        public static IEnumerable<(PropertyInfo propertyInfo, int index, string name)> GetProperties() => GetProperties<Account>().OrderBy(x => x.index);
    }
}
