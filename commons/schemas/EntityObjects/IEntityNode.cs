using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Schemas.EntityObject
{
    public interface IEntityNode<TEntity> : IEntityObject where TEntity : IEntityObject
    {
        /// <summary>
        /// 子階層
        /// </summary>
        [XmlIgnore]
        List<TEntity> Children { get; set; }

        string ToNodeString();
    }
}
