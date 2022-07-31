using System;
using System.Collections.Generic;
using System.Text;

namespace Devices
{
    public interface IHeightAdjustable
    {
        void Raise(float height);
        void Lower(float height);
    }
}
