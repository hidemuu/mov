using System.Xml.Serialization;

namespace Mov.Core.Models.Entities.DbObjects
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
