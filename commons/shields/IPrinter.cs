using Mov.Schemas.Elements;
using Mov.Utilities.Objects.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;

namespace Mov.Controllers.Shields
{
    public interface IPrinter
    {
        void Print(Document document);
    }
}
