using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Exceptions
{
    public sealed class InputException : Exception
    {
        public InputException(string message) : base(message)
        {

        }
    }
}
