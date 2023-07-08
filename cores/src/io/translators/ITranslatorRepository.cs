using Mov.Core.Templates.Repositories;
using Mov.Core.Translators.Schemas;

namespace Mov.Core.Translators
{
    public interface ITranslatorRepository
    {
        IDbObjectRepository<TranslateSchema, TranslateSchemaCollection> Translates { get; }
    }
}