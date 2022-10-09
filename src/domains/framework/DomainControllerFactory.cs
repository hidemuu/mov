using Mov.Accessors.Repository.Domain;
using Mov.Analizer.Models;
using Mov.Configurator.Models;
using Mov.Controllers;
using Mov.Designer.Models;
using Mov.Driver.Models;
using Mov.Game.Models;
using Mov.Translator.Models;
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
                if (service is IConfiguratorService configuratorService)
                {
                    return new DomainController<IConfiguratorService>(configuratorService, this.commandPath);
                }
                if (service is IDesignerService designerService)
                {
                    return new DomainController<IDesignerService>(designerService, this.commandPath);
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
                if (service is ITranslatorService translatorService)
                {
                    return new DomainController<ITranslatorService>(translatorService, this.commandPath);
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
