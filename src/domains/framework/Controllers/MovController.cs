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

namespace Mov.Framework.Controllers
{
    public class MovController
    {

        private IAnalizerRepository analizerRepository;
        private IConfiguratorRepository configuratorRepository;
        private IDesignerRepository designerRepository;
        private IDriverRepository driverRepository;
        private IGameRepository gameRepository;
        private ITranslatorRepository translatorRepository;
        private IController domainController;

        public MovController(IAnalizerRepository analizerRepository, IConfiguratorRepository configuratorRepository,
            IDesignerRepository designerRepository, IDriverRepository driverRepository,
            IGameRepository gameRepository, ITranslatorRepository translatorRepository)
        {
            this.analizerRepository = analizerRepository;
            this.configuratorRepository = configuratorRepository;
            this.designerRepository = designerRepository;
            this.driverRepository = driverRepository;
            this.gameRepository = gameRepository;
            this.translatorRepository = translatorRepository;
        }

    }
}
