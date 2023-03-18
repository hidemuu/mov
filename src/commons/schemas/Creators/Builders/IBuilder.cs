using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Creators.Builders
{
    public interface IBuilder<T>
    {
        T Build();
    }
}
