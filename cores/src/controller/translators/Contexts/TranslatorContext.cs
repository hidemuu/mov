using Mov.Core.Translators.Repositories;
using Mov.Core.Translators.Services;
using System;

namespace Mov.Core.Translators.Contexts
{
    public sealed class TranslatorContext : IDisposable
    {
        #region field

        private readonly ITranslatorService service;

        #endregion field

        #region constructor

        private TranslatorContext(string endpoint)
        {
            if (string.IsNullOrEmpty(endpoint))
            {
                this.service = new NullTranslatorService();
            }
            else
            {
                this.service = new TranslatorService(new FileTranslatorRepository(endpoint));
            }
        }

        private static TranslatorContext instance = new TranslatorContext(string.Empty);

        public static TranslatorContext Current => instance;

        #endregion constructor

        #region method

        public static void Initialize(string endpoint)
        {
            instance = new TranslatorContext(endpoint);
        }

        public void Dispose()
        {
            this.service.Dispose();
        }

        #endregion method
    }
}
