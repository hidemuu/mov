using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Designer.Repository.Persistences.Entities
{
    public class RepositoryLayoutNodeQuery : IPersistenceQuery<LayoutNode>
    {
        #region フィールド

        private readonly IDesignerRepository repository;

        #endregion フィールド

        #region コンストラクター

        public RepositoryLayoutNodeQuery(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerable<LayoutNode> Read()
        {
            return this.repository.Nodes.Read().Items;
        }

        public IEnumerable<LayoutNode> Gets()
        {
            return this.repository.Nodes.Get();
        }

        public IEnumerable<LayoutNode> Gets(string param)
        {
            return Gets().Where(x => x.Code == param);
        }

        public LayoutNode Get(string param)
        {
            return this.repository.Nodes.Get(param);
        }

        public LayoutNode Get(Guid id)
        {
            return this.repository.Nodes.Get(id);
        }

        public override string ToString() => this.repository.Nodes.ToString();

        #endregion メソッド
    }
}
