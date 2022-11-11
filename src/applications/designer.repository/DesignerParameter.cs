using Mov.Designer.Models;
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

        private readonly IDesignerRepository repository;

        #endregion フィールド

        #region プロパティ

        public IDesignerCommand Command { get; }

        public IDesignerQuery Query { get; }

        #endregion プロパティ

        public DesignerParameter(IDesignerRepository repository)
        {
            this.repository = repository;
            this.Command = new DesignerCommand(repository);
            this.Query = new DesignerQuery(repository);
        }
    }
}
