using Mov.Core.Models.Keys;
using Mov.Core.Models.Worlds;
using Mov.Core.Translators.Repositories;
using Mov.Core.Translators.Services;
using System;
using System.Collections.Generic;
using System.Text;

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

        public string Get(string code, Location location)
        {
            return this.service.Get(new IdentifierCode(code), location);
        }

        public void Dispose()
        {
            this.service.Dispose();
        }

        #endregion method
    }
}
