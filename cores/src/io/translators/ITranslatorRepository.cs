using Mov.Core.Repositories;
using Mov.Core.Translators.Models.Schemas;

namespace Mov.Core.Translators
{
    public interface ITranslatorRepository
    {
        IDbObjectRepository<TranslateSchema, int> Translates { get; }
    }
}