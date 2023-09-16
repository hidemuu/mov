using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mov.Core.Repositories
{
    public interface IDbObjectNode<TEntity, TKey> : IDbObject<TKey> where TEntity : IDbObject<TKey>
    {
        #region property

        /// <summary>
        /// 子階層
        /// </summary>
        [XmlIgnore]
        List<TEntity> Children { get; set; }

        #endregion property

        #region method

        string ToNodeString();

        #endregion method
    }
}
