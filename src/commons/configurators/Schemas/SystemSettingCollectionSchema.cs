using Mov.Schemas.EntityObjects.DbObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models.Schemas
{
    public class SystemSettingCollectionSchema : DbObjectCollection<SystemSettingSchema>
    {
        public override SystemSettingSchema[] Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
