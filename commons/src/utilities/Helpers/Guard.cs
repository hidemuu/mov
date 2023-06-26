using Mov.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Helpers
{
    public static class Guard
    {
        public static void IsNull(object obj, string message)
        {
            if(obj == null)
            {
                throw new InputException(message);
            }
        }
    }
}
