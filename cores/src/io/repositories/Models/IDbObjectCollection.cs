using System.Xml.Serialization;

namespace Mov.Core.Repositories.Models
{
    public interface IDbObjectCollection<TEntity> where TEntity : IDbObject
    {
        /// <summary>
        /// コレクション
        /// </summary>
        [XmlIgnore]
        TEntity[] Items { get; set; }
    }
}
