using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface IFileHelper
    {
        T Read<T>();
        void Write<T>(T obj);
    }
}
