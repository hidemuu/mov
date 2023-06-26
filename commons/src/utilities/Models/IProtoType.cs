using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Models
{
    public interface IProtoType<T> where T : new()
    {
        T DeepCopy();
    }
}
