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
            if(service is IConfiguratorService configuratorService)
            {
                return new DomainController<IConfiguratorService>(configuratorService, this.commandPath);
            }
            //if (repository is IDesignerRepository designerRepository)
            //{
            //    return new DomainController<IDesignerRepository>(
            //            designerRepository,
            //            new DesignerService(designerRepository));
            //}
            //if (repository is IGameRepository gameRepository)
            //{
            //    return new DomainController<IGameRepository>(
            //            gameRepository,
            //            new GameService(gameRepository));
            //}
            //if (repository is IDriverRepository driverRepository)
            //{
            //    return new DomainController<IDriverRepository>(
            //            driverRepository,
            //            new DriverService(driverRepository));
            //}
            //if (repository is IAnalizerRepository analizerRepository)
            //{
            //    return new DomainController<IAnalizerRepository>(
            //            analizerRepository,
            //            new AnalizerService(analizerRepository));
            //}
            //if (repository is ITranslatorRepository translatorRepository)
            //{
            //    return new DomainController<ITranslatorRepository>(
            //            translatorRepository,
            //            new TranslatorService(translatorRepository));
            //}
            return null;
        }

    }
}
