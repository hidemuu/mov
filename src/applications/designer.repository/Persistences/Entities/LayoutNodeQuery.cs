using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Designer.Repository.Persistences.Entities
{
    public class LayoutNodeQuery : IPersistenceQuery<LayoutNode>
    {
        #region フィールド

        private readonly IDesignerRepository repository;

        #endregion フィールド

        #region コンストラクター

        public LayoutNodeQuery(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerable<LayoutNode> Get()
        {
            return this.repository.Nodes.Get();
        }

        public IEnumerable<LayoutNode> Get(string param)
        {
            return Get().Where(x => x.Code == param);
        }

        public LayoutNode Get(Guid id)
        {
            return this.repository.Nodes.Get(id);
        }

        public override string ToString() => this.repository.Nodes.ToString();

        #endregion メソッド
    }
}
