﻿using Moq;
using Mov.Core.Configurators.Models.Schemas;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;

namespace Mov.Core.Configurators.Test.Builders
{
    internal class ConfiguratorRepositoryBuilder
    {
        #region field

        private readonly Mock<IConfiguratorRepository> _mockConfiguratorRepository;

        private readonly Mock<IDbRepository<UserSettingSchema, Guid, DbRequestSchemaString>> _mockConfigRepository;

        #endregion field

        #region constructor

        public ConfiguratorRepositoryBuilder()
        {
            _mockConfiguratorRepository = new Mock<IConfiguratorRepository>();
            _mockConfigRepository = new Mock<IDbRepository<UserSettingSchema, Guid, DbRequestSchemaString>>();
        }

        #endregion constructor

        #region method

        public IConfiguratorRepository Build()
        {
            _mockConfiguratorRepository
                .SetupGet<IDbRepository<UserSettingSchema, Guid, DbRequestSchemaString>>(x => x.UserSettings)
                .Returns(_mockConfigRepository.Object)
                .Callback(() => { Console.WriteLine("create config"); });
            return _mockConfiguratorRepository.Object;
        }

        public ConfiguratorRepositoryBuilder WithGetAsyncCalled(IEnumerable<UserSettingSchema> configSchemas)
        {
            _mockConfigRepository
                .Setup(x => x.GetsAsync())
                .ReturnsAsync(configSchemas)
                .Callback(() =>
                {
                    foreach (var configSchema in configSchemas)
                    {
                        Console.WriteLine(configSchema.ToString());
                    }
                });
            return this;
        }

        #endregion method
    }
}
