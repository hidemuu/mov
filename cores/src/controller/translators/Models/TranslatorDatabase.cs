using Mov.Core.Functions;
using Mov.Core.Locations;
using Mov.Core.Models;
using Mov.Core.Models.Identifiers;
using Mov.Core.Translators.Models.Entities;
using Mov.Core.Translators.Models.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mov.Core.Translators.Models
{
    internal sealed class TranslatorDatabase : IDatabase<LocalizeContent, IdentifierIndex>
    {
        #region property

        public IdentifierIndex Id { get; }

        public ICollection<LocalizeContent> Contents { get; } = new HashSet<LocalizeContent>();

        #endregion property

        #region constructor

        public TranslatorDatabase(ITranslatorRepository repository)
        {
            Id = new IdentifierIndex(Thread.CurrentThread.ManagedThreadId);
            var translates = Task.WhenAll(repository.Translates.GetAsync()).Result[0];
            foreach (var translate in translates)
            {
                Contents.Add(
                    new LocalizeContent(
                        new IdentifierIndex(translate.Id),
                        new[] { new LocalizeInfo(Language.EN, new Document(translate.EN)), new LocalizeInfo(Language.JP, new Document(translate.JP)) }
                        )
                    );
            }
        }

        #endregion constructor

        #region method

        public LocalizeContent Get(IdentifierIndex key)
        {
            return Contents.FirstOrDefault(x => x.Index.Equals(key));
        }

        public void Delete(IdentifierIndex key)
        {
            var content = Get(key);
            if (content == null) return;
            Contents.Remove(content);
        }

        public void Put(LocalizeContent value)
        {
            var content = Get(value.Index);
            if (content == null) return;
            Delete(value.Index);
            Contents.Add(content);
        }

        public void Post(LocalizeContent value)
        {
            var content = Get(value.Index);
            if (content == null)
                Contents.Add(value);
            else
                Put(content);
        }

        #endregion method
    }
}