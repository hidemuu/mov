using Moq;
using Mov.Core.Repositories;
using Mov.Core.Translators.Models.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Translators.Test.Builders
{
    internal class TranslatorRepositoryBuilder
    {
        #region field

        private readonly Mock<ITranslatorRepository> _mockRepository;

        private readonly Mock<IDbRepository<TranslateSchema, int>> _mockTranslateRepository;

        #endregion field

        #region constructor

        public TranslatorRepositoryBuilder()
        {
            _mockRepository = new Mock<ITranslatorRepository>();
            _mockTranslateRepository = new Mock<IDbRepository<TranslateSchema, int>>();
        }

        #endregion constructor

        #region method

        public ITranslatorRepository Build()
        {
            _mockRepository
                .SetupGet<IDbRepository<TranslateSchema, int>>(x => x.Translates)
                .Returns(_mockTranslateRepository.Object)
                .Callback(() => { Console.WriteLine("create translate"); });
            return _mockRepository.Object;
        }

        public TranslatorRepositoryBuilder WithGetAsyncCalled(IEnumerable<TranslateSchema> schemas)
        {
            _mockTranslateRepository
                .Setup(x => x.GetAsync())
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
