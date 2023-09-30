using Mov.Core.Repositories;
using Mov.Core.Translators.Models.Schemas;

namespace Mov.Core.Translators
{
    public interface ITranslatorRepository
    {
        IDbRepository<LocalizeSchema, int> Localizes { get; }
    }
}