﻿using Mov.Core.Templates.Repositories;
using Mov.Core.Translators.Repositories.Schemas;

namespace Mov.Core.Translators
{
    public interface ITranslatorRepository
    {
        IDbObjectRepository<TranslateSchema, TranslateSchemaCollection> Translates { get; }
    }
}