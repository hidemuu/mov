using Moq;
using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;
using Mov.Designer.Repository;
using System;

namespace Mov.Designer.Test.Applications.Builders
{
    public class DesignerRepositoryBuilder
    {
        #region フィールド

        private readonly IDesignerRepository repository;
        private readonly Mock<IDbRepository<ContentSchema, Guid>> mockContent;

        #endregion フィールド

        #region コンストラクター

        public DesignerRepositoryBuilder()
        {
            mockContent = new Mock<IDbRepository<ContentSchema, Guid>>();
            repository = new FileDesignerRepository("", FileType.Empty, EncodingValue.Empty);
        }

        #endregion コンストラクター

        #region メソッド

        public IDesignerRepository Build() => repository;

        #endregion メソッド
    }
}