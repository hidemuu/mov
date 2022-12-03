using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Converter
{
    public static class IntConverter
    {
        public static string ToHEX(int val)
        {
            return String.Format("0x{0:x8} [HEX]", val);
        }
    }
}
