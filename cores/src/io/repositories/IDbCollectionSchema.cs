using System.Xml.Serialization;

namespace Mov.Core.Repositories
{
    public interface IDbCollectionSchema<TEntity, TKey> where TEntity : IDbSchema<TKey>
    {
        /// <summary>
        /// コレクション
        /// </summary>
        [XmlIgnore]
        TEntity[] Items { get; set; }
    }
}
