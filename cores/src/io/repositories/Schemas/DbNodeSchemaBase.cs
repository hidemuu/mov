using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Repositories.Schemas
{
    public abstract class DbNodeSchemaBase<TEntity, TKey> : DbSchemaBase<TKey>, IDbNodeSchema<TEntity, TKey> where TEntity : IDbSchema<TKey>
    {
        #region property

        public virtual List<TEntity> Children { get; set; }

        #endregion proeprty

        #region method

        public string ToNodeString()
        {
            var stringBuilder = new StringBuilder(Id.ToString());
            stringBuilder.AppendLine();
            GetStringTables(Children, stringBuilder, 0);
            return stringBuilder.ToString();
        }

        #endregion method

        #region inner method

        private void GetStringTables(List<TEntity> items, StringBuilder stringBuilder, int hierarchy)
        {
            foreach (var item in items)
            {
                for (var i = 0; i <= hierarchy; i++)
                {
                    stringBuilder.Append("  ");
                }
                stringBuilder.AppendLine(item.Id.ToString());
                if (item is DbNodeSchemaBase<TEntity, TKey> node)
                {
                    GetStringTables(node.Children, stringBuilder, hierarchy + 1);
                }
            }
        }

        #endregion inner method
    }
}
