﻿using Moq;
using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;
using Mov.Designer.Repository;
using Mov.Repositories.Services;

namespace Mov.Designer.Test.Builders
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
            this.mockContent = new Mock<IDbObjectRepository<ContentSchema, ContentCollection>>();
            this.repository = new FileDesignerRepository("", "", "");
        }

        #endregion コンストラクター

        #region メソッド

        public IDesignerRepository Build() => this.repository;

        #endregion メソッド
    }
}