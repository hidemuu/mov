using Mov.Core.Stores;
using Mov.Core.Translators.Models.Entities;
using System;
using System.Collections.Generic;

namespace Mov.Core.Translators.Stores.Queries
{
    internal class LocalizeContentReader : IRead<LocalizeContent, int>
    {
        #region field

        private readonly ITranslatorRepository _repository;

        #endregion field

        #region constructor

        public LocalizeContentReader(ITranslatorRepository repository)
        {
            _repository = repository;
        }

        #endregion constructor

        #region method

        public LocalizeContent Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocalizeContent> ReadAll()
        {
            throw new NotImplementedException();
        }

        #endregion method
    }
}
