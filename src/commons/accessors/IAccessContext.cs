using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface IAccessContext
    {
        string Endpoint { get; }

        Encoding Encoding { get; }
    }
}
