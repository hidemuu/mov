using Mov.Schemas.EntityObjects.DbObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models.Schemas
{
    public class LanguageCollectionSchema : DbObjectCollection<LanguageSchema>
    {
        public override LanguageSchema[] Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
