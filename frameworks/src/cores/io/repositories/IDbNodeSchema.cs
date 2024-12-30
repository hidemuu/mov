using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mov.Core.Repositories
{
    public interface IDbNodeSchema<TEntity, TIdentifier> : IDbSchema<TIdentifier> where TEntity : IDbSchema<TIdentifier>
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
