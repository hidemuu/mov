using System;

namespace Mov.Utilities
{
    public static class TraceHelper
    {
        static int level = 0;

        public static T Trace<T>(string frame, string[] args, Func<T> func)
        {
            var s = new string(new char[level]).Replace("\0", "- ") + level + ": " + frame;
            Console.WriteLine(s + " (" + string.Join(",", args) + ")");
            level++;
            var ret = func();
            level--;
            Console.WriteLine(s + " =" + ret);
            return ret;
        }
    }
}
