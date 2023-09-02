using System.Xml.Serialization;

namespace Mov.Core.Repositories
{
    public interface IDbObjectCollection<TEntity, TKey> where TEntity : IDbObject<TKey>
    {
        /// <summary>
        /// コレクション
        /// </summary>
        [XmlIgnore]
        TEntity[] Items { get; set; }
    }
}
