using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mov.Core.Repositories
{
    public interface IDbObjectNode<TKey, TEntity> : IDbObject<TKey> where TEntity : IDbObject<TKey>
    {
        /// <summary>
        /// 子階層
        /// </summary>
        [XmlIgnore]
        List<TEntity> Children { get; set; }

        string ToNodeString();
    }
}
