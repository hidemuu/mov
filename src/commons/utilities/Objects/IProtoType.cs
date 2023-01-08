using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Objects
{
    public interface IProtoType<T> where T : new()
    {
        T DeepCopy();
    }
}
