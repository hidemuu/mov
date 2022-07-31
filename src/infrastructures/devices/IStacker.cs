using System;
using System.Collections.Generic;
using System.Text;

namespace Devices
{
    public interface IStacker
    {
        string GetName();
        void Insert(int row, int col);
        void Eject(int row, int col);
    }
}
