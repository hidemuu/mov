﻿using Mov.Analizer.Engine;
using Mov.Core.Controllers.Services.Controllers;
using Mov.Core.Templates.Controllers;
using Mov.Designer.Engine;
using Mov.Game.Engine;
using System;
using System.Diagnostics;

namespace Mov.Framework.Services
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
                    return new DomainController<IDesignerFacade>(designerService, commandPath);
                }
                if (service is IGameFacade gameService)
                {
                    return new DomainController<IGameFacade>(gameService, commandPath);
                }
                if (service is IAnalizerFacade analizerService)
                {
                    return new DomainController<IAnalizerFacade>(analizerService, commandPath);
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