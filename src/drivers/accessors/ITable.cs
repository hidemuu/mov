using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface ITable<T>
    {
        List<T> Items { get; set; }
    }
}
