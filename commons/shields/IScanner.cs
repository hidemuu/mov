using Mov.Schemas.Elements;
using Mov.Utilities.Objects.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Shields
{
    public interface IScanner
    {
        void Scan(Document document);
    }
}
