﻿using Mov.Designer.Models;
using Mov.Designer.Repository;
using Mov.Drawer.Models;
using Mov.Drawer.Repository;
using Mov.Game.Models;
using Mov.Game.Repository;
using Mov.Repositories.Services;
using Mov.Repositories.Services.Repositories.Domains;

namespace Mov.UseCases.Factories
{
    public class FileDomainRepositoryCollectionFactory
    {
        private readonly string resourcePath;

        public FileDomainRepositoryCollectionFactory(string resourcePath)
        {
            this.resourcePath = resourcePath;
        }

        public IDomainRepositoryCollection<TRepository> Create<TRepository>(string fileType) where TRepository : IDomainRepository
        {
            var repositoryType = typeof(TRepository);
            if (repositoryType == typeof(IDesignerRepository))
            {
                return new FileDomainRepositoryCollection<TRepository, FileDesignerRepository>(
                    this.resourcePath, fileType);
            }
            if (repositoryType == typeof(IDrawerRepository))
            {
                return new FileDomainRepositoryCollection<TRepository, FileDrawerRepository>(
                    this.resourcePath, fileType);
            }
            if (repositoryType == typeof(IGameRepository))
            {
                return new FileDomainRepositoryCollection<TRepository, FileGameRepository>(
                    this.resourcePath, fileType);
            }
            return null;
        }
    }
}