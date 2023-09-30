using Moq;
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


        #endregion field

        #region constructor

        public TranslatorRepositoryBuilder()
        {
            _mockRepository = new Mock<ITranslatorRepository>();
        }

        #endregion constructor

        #region method

        public ITranslatorRepository Build()
        {
            return _mockRepository.Object;
        }

        #endregion method
    }
}
