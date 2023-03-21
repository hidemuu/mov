using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Mov.Loggers.Extensions
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
