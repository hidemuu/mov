using Mov.Accessors.Repository.Domain;
using Mov.Analizer.Models;
using Mov.Controllers;
using Mov.Designer.Models.Services;
using Mov.Driver.Models;
using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

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
                if (service is IGameService gameService)
                {
                    return new DomainController<IGameService>(gameService, this.commandPath);
                }
                if (service is IDriverService driverService)
                {
                    return new DomainController<IDriverService>(driverService, this.commandPath);
                }
                if (service is IAnalizerService analizerService)
                {
                    return new DomainController<IAnalizerService>(analizerService, this.commandPath);
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
