﻿using Mov.Designer.Models;
using Mov.Designer.Models.Parameters;
using Mov.Designer.Models.Persistences;
using Mov.Designer.Repository.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository
{
    public class DesignerParameter : IDesignerParameter
    {
        #region フィールド

        #endregion フィールド

        #region プロパティ

        public IDesignerRepository Repository { get; }

        public IDesignerCommand Command { get; }

        public IDesignerQuery Query { get; }

        #endregion プロパティ

        #region コンストラクター

        public DesignerParameter(IDesignerRepository repository)
        {
            this.Repository = repository;
            this.Command = new RepositoryDesignerCommand(repository);
            this.Query = new RepositoryDesignerQuery(repository);
        }

        #endregion コンストラクター

        #region メソッド

        public void UpdateRepository(string name)
        {

        }

        #endregion メソッド
    }
}