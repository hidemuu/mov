using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Designer.Repository.Persistences.Entities
{
    public class LayoutContentQuery : IPersistenceQuery<LayoutContent>
    {
        #region フィールド

        private readonly IDesignerRepository repository;

        #endregion フィールド

        #region コンストラクター

        public LayoutContentQuery(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerable<LayoutContent> Read()
        {
            return this.repository.Contents.Read().Items;
        }

        public IEnumerable<LayoutContent> Gets()
        {
            return this.repository.Contents.Get();
        }

        public IEnumerable<LayoutContent> Gets(string param)
        {
            return Gets().Where(x => x.Name == param);
        }

        public LayoutContent Get(string param)
        {
            return this.repository.Contents.Get(param);
        }

        public LayoutContent Get(Guid id)
        {
            return this.repository.Contents.Get(id);
        }

        public override string ToString() => this.repository.Contents.ToString();

        #endregion メソッド
    }
}
