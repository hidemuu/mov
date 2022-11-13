using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository.Persistences.Entities
{
    public class RepositoryLayoutNodeCommand : IPersistenceCommand<LayoutNode>
    {
        #region フィールド

        private readonly IDesignerRepository repository;

        #endregion フィールド

        #region コンストラクター

        public RepositoryLayoutNodeCommand(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public void Write()
        {
            this.repository.Nodes.Write();
        }

        public void Delete(LayoutNode item)
        {
            this.repository.Nodes.Delete(item);
        }
        public void Posts(IEnumerable<LayoutNode> items)
        {
            this.repository.Nodes.Posts(items);
        }
        public void Post(LayoutNode item)
        {
            this.repository.Nodes.Post(item);
        }
        public void Put(LayoutNode item)
        {
            this.repository.Nodes.Put(item);
        }

        #endregion メソッド
    }
}
