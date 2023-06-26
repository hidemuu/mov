using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Functions
{
    public interface IStacker
    {
        string GetName();
        void Insert(int row, int col);
        void Eject(int row, int col);
    }
}
