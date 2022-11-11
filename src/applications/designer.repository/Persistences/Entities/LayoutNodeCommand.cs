using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository.Persistences.Entities
{
    public class LayoutNodeCommand : IPersistenceCommand<LayoutNode>
    {
        #region フィールド

        private readonly IDesignerRepository repository;

        #endregion フィールド

        #region コンストラクター

        public LayoutNodeCommand(IDesignerRepository repository)
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

        public void Post(LayoutNode item)
        {
            this.repository.Nodes.Post(item);
        }

        #endregion メソッド
    }
}
