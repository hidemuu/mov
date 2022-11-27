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

        private readonly IDesignerService service;
        private readonly Mock<IDesignerEngine> mockEngine;

        #endregion フィールド

        #region コンストラクター

        public DesignerServiceBuilder()
        {
            this.mockEngine = new Mock<IDesignerEngine>();
            this.service = new DesignerService(this.mockEngine.Object);
        }

        #endregion コンストラクター

        #region メソッド

        public IDesignerService Build() => this.service;

        #endregion メソッド
    }
}
