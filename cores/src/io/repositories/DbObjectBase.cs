using Mov.Core.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Xml.Serialization;

namespace Mov.Core.Repositories
{
    public abstract class DbObjectBase<TKey> : IDbObject<TKey>
    {
        #region property

        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id")]
        [XmlElement("id")]
        [LanguageKey("id")]
        [DisplayName("id")]
        [DisplayIndex(0)]
        public virtual TKey Id { get; set; }

        #endregion property

        #region method

        /// <summary>
        /// プロパティを取得
        /// </summary>
        /// <returns></returns>
        protected static IEnumerable<(PropertyInfo propertyInfo, int index, string name)> GetProperties<T>()
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var index = AttributeHelper.GetAttribute<DisplayIndexAttribute>(property).Index;
                var name = AttributeHelper.GetAttribute<DisplayNameAttribute>(property).DisplayName;
                yield return (property, index, name);
            }
        }

        #endregion method
    }
}
