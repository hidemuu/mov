using System.Xml.Serialization;

namespace Mov.Core.Repositories
{
    public interface IDbCollectionSchema<TEntity, TIdentifier> where TEntity : IDbSchema<TIdentifier>
    {
        /// <summary>
        /// コレクション
        /// </summary>
        [XmlIgnore]
        TEntity[] Items { get; set; }
    }
}
