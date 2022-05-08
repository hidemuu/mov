using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface ISerializer
    {
        T Read<T>();
        void Write<T>(T obj);
    }
}
