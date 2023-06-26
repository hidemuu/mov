using Moq;
using Mov.Designer.Models;
using Mov.Designer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Designer.Test.Applications.Builders
{
    public class DesignerServiceBuilder
    {
        #region フィールド

        private readonly IDesignerFacade service;

        #endregion フィールド

        #region コンストラクター

        public DesignerServiceBuilder()
        {
            //this.service = new DesignerFacade(new IDesignerEngine[] { this.mockEngine.Object });
        }

        #endregion コンストラクター

        #region メソッド

        public IDesignerFacade Build() => this.service;

        #endregion メソッド
    }
}
