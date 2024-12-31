using Mov.Core.Exceptions;

namespace Mov.Core.Helpers
{
    public static class Guard
    {
        public static void IsNull(object obj, string message)
        {
            if (obj == null)
            {
                throw new InputException(message);
            }
        }
    }
}
