using Mov.Core.Stores;
using Mov.Core.Translators.Models.Entities;
using System;
using System.Collections.Generic;

namespace Mov.Core.Translators.Stores.Commands
{
    internal class LocalizeContentSaver : ISave<LocalizeContent>
    {
        #region field

        private readonly ITranslatorRepository _repository;

        #endregion field

        #region constructor

        public LocalizeContentSaver(ITranslatorRepository repository)
        {
            _repository = repository;
        }

        #endregion constructor

        #region method

        public void Save(LocalizeContent entity)
        {
            throw new NotImplementedException();
        }

		public void Save(IEnumerable<LocalizeContent> entities)
		{
			throw new NotImplementedException();
		}

		#endregion method
	}
}
