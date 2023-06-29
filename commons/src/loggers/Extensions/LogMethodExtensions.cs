using System.Diagnostics;
using System.Reflection;

namespace Mov.Core.Loggers.Extensions
{
    public static class LogMethodExtensions
    {
        public static string GetExecutionTimeFormat(this MethodBase method, Stopwatch stopwatch)
        {
            return string.Join(LogConstants.SEPALATOR,
                $"{LogConstants.METHOD}{LogConstants.PUNCTUATON_MARK}{method.Name}",
                $"{LogConstants.EXECUTION_TIME}{LogConstants.PUNCTUATON_MARK}{stopwatch.ElapsedMilliseconds}{LogConstants.MILLI_SECOND}");

        }
    }
}
