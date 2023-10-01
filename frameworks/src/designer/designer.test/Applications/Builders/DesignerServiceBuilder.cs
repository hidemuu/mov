using Mov.Designer.Service;

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