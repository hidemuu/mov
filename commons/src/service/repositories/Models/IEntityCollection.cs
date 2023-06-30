using System.Xml.Serialization;

namespace Mov.Core.Repositories.Models
{
    public interface IEntityCollection<TEntity> where TEntity : IEntityObject
    {
        /// <summary>
        /// コレクション
        /// </summary>
        [XmlIgnore]
        TEntity[] Items { get; set; }
    }
}
