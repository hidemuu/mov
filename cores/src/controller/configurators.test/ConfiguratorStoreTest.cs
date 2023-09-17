using Mov.Core.Configurators.Models.Schemas;
using Mov.Core.Configurators.Stores;
using Mov.Core.Configurators.Test.Builders;

namespace Mov.Core.Configurators.Test
{
    public class ConfiguratorStoreTest
    {
        #region field

        private ConfiguratorRepositoryBuilder _repositoryBuilder;

        #endregion field

        #region setup

        [SetUp]
        public void Setup()
        {
            _repositoryBuilder = new ConfiguratorRepositoryBuilder();
        }

        #endregion setup

        #region test

        [Test]
        public void ReadAll_UserSettings_Return()
        {
            // Arrange
            IEnumerable<ConfigSchema> schemas = new[]
                {
                    new ConfigSchema()
                    {
                        Id = Guid.NewGuid(),
                        Index = 1,
                        Code = "test",
                    },
                    new ConfigSchema()
                    {
                        Id = Guid.NewGuid(),
                        Index = 2,
                        Code = "test2",
                    },
                };
            var repository = _repositoryBuilder
                .WithGetAsyncCalled(schemas)
                .Build();

            var sut = new ConfiguratorStore(repository);

            // Act
            var userSettings = sut.UserSetting.Query.Reader.ReadAll().ToArray();

            // Assert
            Assert.That(userSettings.Length, Is.EqualTo(2));
            Assert.That(userSettings[0].Code.Value, Is.EqualTo("test"));
            Assert.That(userSettings[1].Code.Value, Is.EqualTo("test2"));
        }

        #endregion test
    }
}
