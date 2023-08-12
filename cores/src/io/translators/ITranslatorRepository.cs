using Mov.Core.Repositories;
using Mov.Core.Translators.Repositories.Schemas;

namespace Mov.Core.Translators
{
    public interface ITranslatorRepository
    {
        IDbObjectRepository<TranslateSchema, int> Translates { get; }
    }
}