using Mov.Core.Models.Keys;
using Mov.Core.Models.Units;
using Mov.Core.Templates;
using Mov.Core.Translators.Models.Entities;
using Mov.Core.Translators.Models.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Mov.Core.Translators.Repositories
{
    internal sealed class TranslatorDatabase : IDatabase<LocalizeContent, IdentifierCode>
    {
        #region property

        public IdentifierIndex Id { get; }

        public ICollection<LocalizeContent> Contents { get; } = new HashSet<LocalizeContent>();

        #endregion property

        #region constructor

        public TranslatorDatabase(ITranslatorRepository repository)
        {
            Id = new IdentifierIndex(Thread.CurrentThread.ManagedThreadId);
            var translates = repository.Translates.Get();
            foreach (var translate in translates)
            {
                Contents.Add(
                    new LocalizeContent(
                        new Identifier(translate.Id),
                        new IdentifierIndex(translate.Index),
                        new IdentifierCode(translate.Code),
                        new[] { new LocalizeInfo(Location.EN, new Info(translate.EN)), new LocalizeInfo(Location.JP, new Info(translate.JP)) }
                        )
                    );                        
            }
        }

        #endregion constructor

        #region method

        public LocalizeContent Get(IdentifierCode key)
        {
            return Contents.FirstOrDefault(x => x.Code.Equals(key));
        }

        public void Delete(IdentifierCode key)
        {
            var content = Get(key);
            if (content == null) return;
            Contents.Remove(content);
        }

        public void Put(LocalizeContent value)
        {
            var content = Get(value.Code);
            if (content == null) return;
            Delete(value.Code);
            Contents.Add(content);
        }

        public void Post(LocalizeContent value)
        {
            var content = Get(value.Code);
            if (content == null)
                Contents.Add(value);
            else
                Put(content);
        }

        #endregion method
    }
}