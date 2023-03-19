using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Mov.Loggers.NLogs.Aspects
{
    [AttributeUsage(AttributeTargets.Method)]
    public class LogExecutionTimeAttribute : Attribute
    {
        public void OnEntry(MethodBase method, object[] args, Stopwatch stopwatch)
        {
            stopwatch.Start();
        }

        public void OnExit(MethodBase method, object returnValue, Stopwatch stopwatch)
        {
            stopwatch.Stop();
            LogAspect.LogExecutionTime(method, stopwatch);
        }
    }
}
