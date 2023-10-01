using Mov.Framework;
using Mov.Framework.Services;
using Mov.UseCase.Repositories;

namespace Mov.UseCase.Controllers
{
    public class WebAppController : IWebAppController
    {
        #region field


        #endregion field

        #region property

        public IMovRepository Repository { get; }

        #endregion property

        #region constructor

        public WebAppController()
        {
            this.Repository = new FileMovRepository(PathCreator.GetResourcePath());
        }

        #endregion constructor

    }
}
