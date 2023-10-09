using Mov.Analizer.Service;
using Mov.Core.Commands;
using Mov.Core.Commands.Services;
using Mov.Designer.Service;
using Mov.Game.Service;
using System;
using System.Diagnostics;

namespace Mov.Framework.Services
{
    /// <summary>
    /// ドメインコントローラー生成
    /// </summary>
    public class DomainControllerFactory
    {
        #region field

        private string _commandPath;

        #endregion field

        #region constructor

        public DomainControllerFactory(string commandPath)
        {
            this._commandPath = commandPath;
        }

        #endregion constructor

        #region method

        public IUiController Create<TService>(TService service)
        {
            try
            {
                //return new DomainController<TService>(service, this.commandPath);
                if (service is IDesignerFacade designerService)
                {
                    return new UiCommandController<IDesignerFacade>(designerService, _commandPath);
                }
                if (service is IGameFacade gameService)
                {
                    return new UiCommandController<IGameFacade>(gameService, _commandPath);
                }
                if (service is IAnalizerFacade analizerService)
                {
                    return new UiCommandController<IAnalizerFacade>(analizerService, _commandPath);
                }
            }
            catch (Exception ex)
            {
                Debug.Assert(false, "サービスが見つかりません" + Environment.NewLine + ex.Message);
            }
            return null;
        }

        #endregion method
    }
}