﻿using Mov.Designer.Models;
using Mov.Designer.Models.Parameters;
using Mov.Designer.Models.Persistences;
using Mov.Designer.Models.Repositories;
using Mov.Designer.Repository.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository.Parameters
{
    public class DesignerCollectionParameter : IDesignerParameter
    {
        #region フィールド

        private readonly IDesignerRepositoryCollection repositories;

        #endregion フィールド

        #region プロパティ

        public IDesignerRepository Repository { get; private set; }

        public IDesignerCommand Command { get; private set; }

        public IDesignerQuery Query { get; private set; }

        #endregion プロパティ

        #region コンストラクター

        public DesignerCollectionParameter(IDesignerRepositoryCollection repositories)
        {
            this.repositories = repositories;
            UpdateRepository("dashboard");
        }

        #endregion コンストラクター

        #region メソッド

        public void UpdateRepository(string name)
        {
            var repository = repositories.GetRepository(name);
            this.Repository = repository;
            this.Command = new RepositoryDesignerCommand(repository);
            this.Query = new RepositoryDesignerQuery(repository);
        }

        #endregion メソッド
    }
}