using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mov.Core.Repositories.Models
{
    public interface IDbObjectNode<TEntity> : IDbObject where TEntity : IDbObject
    {
        /// <summary>
        /// 子階層
        /// </summary>
        [XmlIgnore]
        List<TEntity> Children { get; set; }

        string ToNodeString();
    }
}
