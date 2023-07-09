using Mov.Core.Contexts.Personals;
using Mov.Core.Contexts.Personals.ValueObjects;
using Mov.Core.Contexts.Structures;
using Mov.Core.Models.Keys;
using Mov.Core.Models.Units;
using Mov.Core.Templates;
using Mov.Core.Translators.Models.Entities;
using Mov.Core.Translators.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Mov.Core.Translators.Contexts
{
    public sealed class TranslatorDatabase : IDatabase<LocalizeContent, Identifier>
    {
        #region field

        
        #endregion field

        #region property

        public IdentifierIndex Id { get; }

        public IEnumerable<LocalizeContent> Contents { get; } = new HashSet<LocalizeContent>();

        #endregion property

        #region constructor

        public TranslatorDatabase(ITranslatorRepository repository)
        {
            Id = new IdentifierIndex(Thread.CurrentThread.ManagedThreadId);
        }

        #endregion constructor

        #region method

        public LocalizeContent Get(Identifier key)
        {
            throw new NotImplementedException();
        }

        public void Delete(Identifier key)
        {
            throw new NotImplementedException();
        }

        public void Put(LocalizeContent value)
        {
            throw new NotImplementedException();
        }

        public void Post(LocalizeContent value)
        {
            throw new NotImplementedException();
        }

        #endregion method
    }
}
