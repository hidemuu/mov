using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository.Persistences.Entities
{
    public class ShellCommand : IPersistenceCommand<Shell>
    {
        #region フィールド

        private readonly IDesignerRepository repository;

        #endregion フィールド

        #region コンストラクター

        public ShellCommand(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public void Delete(Shell item)
        {
            this.repository.Shells.Delete(item);
        }

        public void Post(Shell item)
        {
            this.repository.Shells.Post(item);
        }

        #endregion メソッド
    }
}
