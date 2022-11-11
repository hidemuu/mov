using Mov.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Mov.Analizer.Models;
using Mov.Designer.Models;
using Mov.Driver.Models;
using Mov.Game.Models;
using Mov.UseCases.Factories;
using Mov.Accessors;

namespace Mov.UseCases.Repositories
{
    public class FileMovRepository : IMovRepository
    {
        public IAnalizerRepository Analizer { get; }
        public IDesignerRepository Designer { get; }
        public IDriverRepository Driver { get; }
        public IGameRepository Game { get; }

        public FileMovRepository(string endpoint)
        {
            var fileRepositoryFactory = new FileDomainRepositoryCollectionFactory(endpoint);
            this.Designer = fileRepositoryFactory.Create<IDesignerRepository>(SerializeConstants.PATH_XML)?.GetDefaultRepository();
            this.Game = fileRepositoryFactory.Create<IGameRepository>(SerializeConstants.PATH_JSON)?.GetDefaultRepository();
            this.Driver = fileRepositoryFactory.Create<IDriverRepository>(SerializeConstants.PATH_JSON)?.GetDefaultRepository();
            this.Analizer = fileRepositoryFactory.Create<IAnalizerRepository>(SerializeConstants.PATH_JSON)?.GetDefaultRepository();
        }

        
    }
}
