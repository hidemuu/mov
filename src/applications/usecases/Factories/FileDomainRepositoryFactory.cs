using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Implement;
using Mov.Configurator.Models;
using Mov.Configurator.Repository;
using Mov.Designer.Models;
using Mov.Designer.Repository;
using Mov.Drawer.Models;
using Mov.Drawer.Repository;
using Mov.Driver.Models;
using Mov.Driver.Repository;
using Mov.Game.Models;
using Mov.Game.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Mov.UseCases.Factories
{
    public class FileDomainRepositoryFactory
    {

        private readonly string resourcePath;

        public FileDomainRepositoryFactory(string resourcePath)
        {
            this.resourcePath = resourcePath;
        }

        public IDomainRepositoryCollection<TRepository> Create<TRepository>(string fileType)
        {
            var repositoryType = typeof(TRepository);
            if (repositoryType is IConfiguratorRepository)
            {
                return new FileDomainRepositoryCollection<TRepository, FileConfiguratorRepository>(
                    Path.Combine(this.resourcePath, "configurator"), fileType);
            }
            if (repositoryType is IDesignerRepository)
            {
                return new FileDomainRepositoryCollection<TRepository, FileDesignerRepository>(
                    Path.Combine(this.resourcePath, "designer"), fileType);
            }
            if (repositoryType is IDrawerRepository)
            {
                return new FileDomainRepositoryCollection<TRepository, FileDrawerRepository>(
                    Path.Combine(this.resourcePath, "drawer"), fileType);
            }
            if (repositoryType is IDriverRepository)
            {
                return new FileDomainRepositoryCollection<TRepository, FileDriverRepository>(
                    Path.Combine(this.resourcePath, "driver"), fileType);
            }
            if (repositoryType is IGameRepository)
            {
                return new FileDomainRepositoryCollection<TRepository, FileGameRepository>(
                    Path.Combine(this.resourcePath, "game"), fileType);
            }
            return null;
        }
    }
}
