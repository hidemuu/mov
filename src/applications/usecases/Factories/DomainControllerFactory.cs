using Mov.Accessors.Repository.Domain;
using Mov.Analizer.Models;
using Mov.Analizer.Service;
using Mov.Configurator.Models;
using Mov.Configurator.Service;
using Mov.Controllers;
using Mov.Controllers.Service;
using Mov.Designer.Models;
using Mov.Designer.Service;
using Mov.Driver.Models;
using Mov.Driver.Service;
using Mov.Game.Models;
using Mov.Game.Service;
using Mov.Translator.Models;
using Mov.Translator.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.UseCases.Factories
{
    public class DomainControllerFactory<TRepository>
    {
        public DomainControllerFactory()
        {

        }

        public IController Create(TRepository repository)
        {
            if(repository is IConfiguratorRepository configuratorRepository)
            {
                return new DomainController<IConfiguratorRepository>(
                        configuratorRepository,
                        new ConfiguratorService(configuratorRepository));
            }
            if (repository is IDesignerRepository designerRepository)
            {
                return new DomainController<IDesignerRepository>(
                        designerRepository,
                        new DesignerService(designerRepository));
            }
            if (repository is IGameRepository gameRepository)
            {
                return new DomainController<IGameRepository>(
                        gameRepository,
                        new GameService(gameRepository));
            }
            if (repository is IDriverRepository driverRepository)
            {
                return new DomainController<IDriverRepository>(
                        driverRepository,
                        new DriverService(driverRepository));
            }
            if (repository is IAnalizerRepository analizerRepository)
            {
                return new DomainController<IAnalizerRepository>(
                        analizerRepository,
                        new AnalizerService(analizerRepository));
            }
            if (repository is ITranslatorRepository translatorRepository)
            {
                return new DomainController<ITranslatorRepository>(
                        translatorRepository,
                        new TranslatorService(translatorRepository));
            }
            return null;
        }

    }
}
