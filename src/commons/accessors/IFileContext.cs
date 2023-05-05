using Mov.Schemas.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface IFileContext
    {
        FileUnit Endpoint { get; }

        Encoding Encoding { get; }
    }
}
