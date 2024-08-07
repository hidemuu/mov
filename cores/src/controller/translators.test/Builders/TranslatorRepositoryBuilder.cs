﻿using Moq;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Core.Translators.Models.Schemas;

namespace Mov.Core.Translators.Test.Builders
{
    internal class TranslatorRepositoryBuilder
    {
        #region field

        private readonly Mock<ITranslatorRepository> _mockRepository;

        private readonly Mock<IDbRepository<LocalizeSchema, int, DbRequestSchemaString>> _mockTranslateRepository;

        #endregion field

        #region constructor

        public TranslatorRepositoryBuilder()
        {
            _mockRepository = new Mock<ITranslatorRepository>();
            _mockTranslateRepository = new Mock<IDbRepository<LocalizeSchema, int, DbRequestSchemaString>>();
        }

        #endregion constructor

        #region method

        public ITranslatorRepository Build()
        {
            _mockRepository
                .SetupGet<IDbRepository<LocalizeSchema, int, DbRequestSchemaString>>(x => x.Localizes)
                .Returns(_mockTranslateRepository.Object)
                .Callback(() => { Console.WriteLine("create translate"); });
            return _mockRepository.Object;
        }

        public TranslatorRepositoryBuilder WithGetAsyncCalled(IEnumerable<LocalizeSchema> schemas)
        {
            _mockTranslateRepository
                .Setup(x => x.GetsAsync())
                .ReturnsAsync(schemas)
                .Callback(() =>
                {
                    foreach (var schema in schemas)
                    {
                        Console.WriteLine(schema.ToString());
                    }
                });
            return this;
        }

        #endregion method
    }
}
