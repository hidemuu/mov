using Mov.Analizer.Models;
using Mov.Core.Controllers.Services.Controllers;
using Mov.Core.Templates;
using Mov.Designer.Models;
using Mov.Game.Engine;
using System;
using System.Diagnostics;

namespace Mov.Framework
{
    /// <summary>
    /// ドメインコントローラー生成
    /// </summary>
    public class DomainControllerFactory
    {
        private string commandPath;

        public DomainControllerFactory(string commandPath)
        {
            this.commandPath = commandPath;
        }

        public IController Create<TService>(TService service)
        {
            try
            {
                //return new DomainController<TService>(service, this.commandPath);
                if (service is IDesignerFacade designerService)
                {
                    return new DomainController<IDesignerFacade>(designerService, this.commandPath);
                }
                if (service is IGameFacade gameService)
                {
                    return new DomainController<IGameFacade>(gameService, this.commandPath);
                }
                if (service is IAnalizerFacade analizerService)
                {
                    return new DomainController<IAnalizerFacade>(analizerService, this.commandPath);
                }
            }
            catch (Exception ex)
            {
                Debug.Assert(false, "サービスが見つかりません" + Environment.NewLine + ex.Message);
            }
            return null;
        }
    }
}