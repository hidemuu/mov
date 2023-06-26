using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Shields
{
    public interface IHeightAdjustable
    {
        void Raise(float height);
        void Lower(float height);
    }
}
