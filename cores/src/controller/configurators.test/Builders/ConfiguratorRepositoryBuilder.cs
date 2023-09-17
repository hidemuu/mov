using Moq;
using Mov.Core.Configurators.Models.Schemas;
using Mov.Core.Repositories;

namespace Mov.Core.Configurators.Test.Builders
{
    internal class ConfiguratorRepositoryBuilder
    {
        #region field

        private readonly Mock<IConfiguratorRepository> _mockConfiguratorRepository;

        private readonly Mock<IDbRepository<ConfigSchema, Guid>> _mockConfigRepository;

        #endregion field

        #region constructor

        public ConfiguratorRepositoryBuilder()
        {
            _mockConfiguratorRepository = new Mock<IConfiguratorRepository>();
            _mockConfigRepository = new Mock<IDbRepository<ConfigSchema, Guid>>();
        }

        #endregion constructor

        #region method

        public IConfiguratorRepository Build()
        {
            _mockConfiguratorRepository
                .SetupGet<IDbRepository<ConfigSchema, Guid>>(x => x.Configs)
                .Returns(_mockConfigRepository.Object)
                .Callback(() => { Console.WriteLine("create config"); });
            return _mockConfiguratorRepository.Object;
        }

        public ConfiguratorRepositoryBuilder WithGetAsyncCalled(IEnumerable<ConfigSchema> configSchemas)
        {
            _mockConfigRepository
                .Setup(x => x.GetAsync())
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
