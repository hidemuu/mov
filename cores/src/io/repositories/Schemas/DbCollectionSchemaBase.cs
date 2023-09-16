using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Core.Repositories.Schemas
{
    public abstract class DbCollectionSchemaBase<TEntity, TKey> : IDbCollectionSchema<TEntity, TKey> where TEntity : IDbSchema<TKey>
    {
        #region property

        [XmlIgnore]
        public virtual TEntity[] Items { get; set; }

        #endregion property

        #region method

        /// <summary>
        /// 文字列生成
        /// </summary>
        /// <returns></returns>
        public string ToStrings()
        {
            var stringBuilder = new StringBuilder();
            GetStrings(Items, stringBuilder, 0);
            return stringBuilder.ToString();
        }

        #endregion method

        #region inner method

        /// <summary>
        /// 文字列生成
        /// </summary>
        /// <param name="items"></param>
        /// <param name="stringBuilder"></param>
        /// <param name="hierarchy"></param>
        private void GetStrings(IEnumerable<TEntity> items, StringBuilder stringBuilder, int hierarchy)
        {
            foreach (var item in items)
            {
                for (var i = 0; i < hierarchy; i++)
                {
                    stringBuilder.Append("  ");
                }
                stringBuilder.AppendLine(item.ToString());
            }
        }

        #endregion inner method
    }
}
