using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Objects
{
    public class Ref<T> where T : class
    {
        public T Value;

        public Ref(T value)
        {
            Value = value;
        }
    }
}
