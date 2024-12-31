using Mov.Core.Stores;
using Mov.Core.Translators.Models.Entities;

namespace Mov.Core.Translators
{
    public interface ITranslatorStore
    {
        IStore<LocalizeContent, int> LocalizeContent { get; }
    }
}
