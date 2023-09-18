using Mov.Core.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Xml.Serialization;

namespace Mov.Core.Repositories.Schemas
{
    public abstract class DbSchemaBase<TIdentifier> : IDbSchema<TIdentifier>
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
        public virtual TIdentifier Id { get; set; }

        #endregion property

        #region constructor

        public DbSchemaBase() { }

        public DbSchemaBase(IDbSchema<TIdentifier> src)
        {
            Id = src.Id;
        }

        #endregion constructor

        #region method

        public override string ToString()
        {
            return Id.ToString();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var vo = obj as DbSchemaBase<TIdentifier>;
            if (vo == null) return false;
            return Id.Equals(vo.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion method

        #region inner method

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

        #endregion inner method
    }
}
