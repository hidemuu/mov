﻿using Mov.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Mov.Analizer.Models;
using Mov.Configurator.Models;
using Mov.Designer.Models;
using Mov.Driver.Models;
using Mov.Game.Models;
using Mov.Translator.Models;
using Mov.UseCases.Factories;
using Mov.Accessors;

namespace Mov.UseCases.Repositories
{
    public class FileMovRepository : IMovRepository
    {
        public IAnalizerRepository Analizer { get; }
        public IConfiguratorRepository Configurator { get; }
        public IDesignerRepository Designer { get; }
        public IDriverRepository Driver { get; }
        public IGameRepository Game { get; }
        public ITranslatorRepository Translator { get; }

        public FileMovRepository(string endpoint)
        {
            var fileRepositoryFactory = new FileDomainRepositoryCollectionFactory(endpoint);
            this.Configurator = fileRepositoryFactory.Create<IConfiguratorRepository>(SerializeConstants.PATH_JSON)?.DefaultRepository;
            this.Designer = fileRepositoryFactory.Create<IDesignerRepository>(SerializeConstants.PATH_XML)?.DefaultRepository;
            this.Game = fileRepositoryFactory.Create<IGameRepository>(SerializeConstants.PATH_JSON)?.DefaultRepository;
            this.Driver = fileRepositoryFactory.Create<IDriverRepository>(SerializeConstants.PATH_JSON)?.DefaultRepository;
            this.Analizer = fileRepositoryFactory.Create<IAnalizerRepository>(SerializeConstants.PATH_JSON)?.DefaultRepository;
            this.Translator = fileRepositoryFactory.Create<ITranslatorRepository>(SerializeConstants.PATH_JSON)?.DefaultRepository;
        }

        
    }
}