using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Repositories.Models
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
