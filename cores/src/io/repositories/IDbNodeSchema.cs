using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mov.Core.Repositories
{
    public interface IDbNodeSchema<TEntity, TKey> : IDbSchema<TKey> where TEntity : IDbSchema<TKey>
    {
        #region property

        /// <summary>
        /// 子階層
        /// </summary>
        [XmlIgnore]
        List<TEntity> Children { get; set; }

        #endregion property

    }
}
