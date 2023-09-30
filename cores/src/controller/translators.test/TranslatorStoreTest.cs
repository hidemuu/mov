using Mov.Core.Translators.Models.Schemas;
using Mov.Core.Translators.Stores;
using Mov.Core.Translators.Test.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Translators.Test
{
    public class TranslatorStoreTest
    {
        #region field

        private TranslatorRepositoryBuilder _repositoryBuilder;

        #endregion field

        #region setup

        [SetUp]
        public void Setup()
        {
            _repositoryBuilder = new TranslatorRepositoryBuilder();
        }

        #endregion setup

        #region test

        [Test]
        public void ReadAll_UserSettings_Return()
        {
            // Arrange
            IEnumerable<LocalizeSchema> schemas = new[]
                {
                    new LocalizeSchema()
                    {
                        Id = 1,
                        JP = "test",
                        EN = "test",
                    },
                    new LocalizeSchema()
                    {
                        Id = 1,
                        JP = "test2",
                        EN = "test2",
                    },
                };
            var repository = _repositoryBuilder
                .WithGetAsyncCalled(schemas)
                .Build();

            var sut = new TranslatorStore(repository);

            // Act
            var localizeContents = sut.LocalizeContent.Query.Reader.ReadAll().ToArray();

            // Assert
            Assert.That(localizeContents.Length, Is.EqualTo(2));
        }

        #endregion test
    }
}
