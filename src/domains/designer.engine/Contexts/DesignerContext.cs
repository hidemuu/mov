﻿using Mov.Designer.Engine.Persistences;
using Mov.Designer.Models;
using Mov.Designer.Models.Parameters;
using Mov.Designer.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Engine
{
    public class DesignerContext : IDesignerContext
    {
        #region フィールド

        #endregion フィールド

        #region プロパティ

        public string EndPoint { get; }

        public IDesignerRepository Repository { get; }

        public IDesignerCommand Command { get; }

        public IDesignerQuery Query { get; }

        #endregion プロパティ

        #region コンストラクター

        public DesignerContext(IDesignerRepository repository, string endpoint)
        {
            this.EndPoint = endpoint;
            this.Repository = repository;
            this.Command = new RepositoryDesignerCommand(repository);
            this.Query = new RepositoryDesignerQuery(repository);
        }

        #endregion コンストラクター

        #region メソッド

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion メソッド

    }
}