using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToFormatString(this object val)
        {
            return val.ToString();
        }
    }
}
