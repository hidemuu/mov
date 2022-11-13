using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository.Persistences.Entities
{
    public class RepositoryLayoutContentCommand : IPersistenceCommand<LayoutContent>
    {
        #region フィールド

        private readonly IDesignerRepository repository;

        #endregion フィールド

        #region コンストラクター

        public RepositoryLayoutContentCommand(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public void Write()
        {
            this.repository.Contents.Write();
        }

        public void Delete(LayoutContent item)
        {
            this.repository.Contents.Delete(item);
        }
        public void Posts(IEnumerable<LayoutContent> items)
        {
            this.repository.Contents.Posts(items);
        }
        public void Post(LayoutContent item)
        {
            this.repository.Contents.Post(item);
        }

        public void Put(LayoutContent item)
        {
            this.repository.Contents.Put(item);
        }

        #endregion メソッド
    }
}
