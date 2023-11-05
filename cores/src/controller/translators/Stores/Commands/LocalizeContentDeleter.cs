using Mov.Core.Stores;
using Mov.Core.Translators.Models.Entities;
using System;

namespace Mov.Core.Translators.Stores.Commands
{
    internal class LocalizeContentDeleter : IDelete<LocalizeContent>
    {
        #region field

        private readonly ITranslatorRepository _repository;

        #endregion field

        #region constructor

        public LocalizeContentDeleter(ITranslatorRepository repository)
        {
            _repository = repository;
        }

		#endregion constructor

		#region method

		public void Delete(LocalizeContent entity)
        {
            throw new NotImplementedException();
        }

		public void Clear()
		{
			throw new NotImplementedException();
		}

		#endregion method
	}
}
