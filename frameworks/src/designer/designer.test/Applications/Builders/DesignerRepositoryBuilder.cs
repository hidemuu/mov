using Moq;
using Mov.Core.Templates.Repositories;
using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;
using Mov.Designer.Repository.File;

namespace Mov.Designer.Test.Applications.Builders
{
    public class DesignerRepositoryBuilder
    {
        #region フィールド

        private readonly IDesignerRepository repository;
        private readonly Mock<IDbObjectRepository<ContentSchema, ContentCollection>> mockContent;

        #endregion フィールド

        #region コンストラクター

        public DesignerRepositoryBuilder()
        {
            mockContent = new Mock<IDbObjectRepository<ContentSchema, ContentCollection>>();
            repository = new FileDesignerRepository("", "", "");
        }

        #endregion コンストラクター

        #region メソッド

        public IDesignerRepository Build() => repository;

        #endregion メソッド
    }
}