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
    public class MovEngine : IMovEngine
    {

        private IAnalizerService analizerService;
        private IConfiguratorService configuratorService;
        private IDesignerService designerService;
        private IDriverService driverService;
        private IGameService gameService;
        private ITranslatorService translatorService;

        public MovEngine(IAnalizerService analizerService, IConfiguratorService configuratorService,
            IDesignerService designerService, IDriverService driverService,
            IGameService gameService, ITranslatorService translatorService)
        {
            this.analizerService = analizerService;
            this.configuratorService = configuratorService;
            this.designerService = designerService;
            this.driverService = driverService;
            this.gameService = gameService;
            this.translatorService = translatorService;
        }

    }
}
