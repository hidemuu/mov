using Mov.Core.Contexts.Personals;
using Mov.Core.Contexts.Personals.ValueObjects;
using Mov.Core.Contexts.Structures;
using Mov.Core.Extensions;
using Mov.Core.Models.Keys;
using Mov.Core.Models.Units;
using Mov.Core.Templates;
using Mov.Core.Translators.Models.Entities;
using Mov.Core.Translators.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public ICollection<LocalizeContent> Contents { get; } = new HashSet<LocalizeContent>();

        #endregion property

        #region constructor

        public TranslatorDatabase(ITranslatorRepository repository)
        {
            Id = new IdentifierIndex(Thread.CurrentThread.ManagedThreadId);
            var translates = repository.Translates.Get();
            foreach(var translate in translates )
            {
                Contents.Add(
                    new LocalizeContent(
                        new Identifier(translate.Id),
                        new IdentifierIndex(translate.Index),
                        new LocalizeInfo(Location.EN, new Info(translate.EN)),
                        new LocalizeInfo(Location.JP, new Info(translate.JP))));
            }
        }

        #endregion constructor

        #region method

        public LocalizeContent Get(Identifier key)
        {
            return Contents.FirstOrDefault(x => x.Id.Equals(key));
        }

        public void Delete(Identifier key)
        {
            var content = Get(key);
            if (content == null) return;
            Contents.Remove(content);
        }

        public void Put(LocalizeContent value)
        {
            var content = Get(value.Id);
            if (content == null) return;
            Delete(value.Id);
            Contents.Add(content);
        }

        public void Post(LocalizeContent value)
        {
            var content = Get(value.Id);
            if (content == null) 
                Contents.Add(value);
            else 
                Put(content);
        }

        #endregion method
    }
}
