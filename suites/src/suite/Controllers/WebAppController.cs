using Mov.Framework.Services;
using Mov.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Suite.Controllers
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
            
        }

        #endregion constructor

    }
}
