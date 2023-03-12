using Moq;
using Mov.Accessors;
using Mov.Designer.Models;
using Mov.Designer.Models.Entities;
using Mov.Designer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Designer.Test.Builders
{
    public class DesignerRepositoryBuilder
    {
        #region フィールド

        private readonly IDesignerRepository repository;
        private readonly Mock<IDbObjectRepository<Content, ContentCollection>> mockContent;

        #endregion フィールド

        #region コンストラクター

        public DesignerRepositoryBuilder()
        {
            this.mockContent = new Mock<IDbObjectRepository<Content, ContentCollection>>();
            this.repository = new FileDesignerRepository("", "", "");
        }

        #endregion コンストラクター

        #region メソッド

        public IDesignerRepository Build() => this.repository;

        #endregion メソッド
    }
}
