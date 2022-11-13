using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository.Persistences.Entities
{
    public class RepositoryShellCommand : IPersistenceCommand<Shell>
    {
        #region フィールド

        private readonly IDesignerRepository repository;

        #endregion フィールド

        #region コンストラクター

        public RepositoryShellCommand(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public void Write()
        {
            this.repository.Shells.Write();
        }

        public void Delete(Shell item)
        {
            this.repository.Shells.Delete(item);
        }
        public void Posts(IEnumerable<Shell> items)
        {
            this.repository.Shells.Posts(items);
        }
        public void Post(Shell item)
        {
            this.repository.Shells.Post(item);
        }
        public void Put(Shell item)
        {
            this.repository.Shells.Put(item);
        }

        #endregion メソッド
    }
}
