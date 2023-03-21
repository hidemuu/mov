using MethodBoundaryAspect.Fody.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Mov.Loggers.NLogs
{
    public sealed class LogExecutionTimeAttribute : OnMethodBoundaryAspect
    {

        private Stopwatch stopwatch = new Stopwatch();

        public override void OnEntry(MethodExecutionArgs arg)
        {
            stopwatch.Start();
            Console.WriteLine("Entered method: " + arg.Method.Name);
        }

        public override void OnExit(MethodExecutionArgs arg)
        {
            stopwatch.Stop();
            LogContext.Instance.LogExecutionTime(arg.Method, stopwatch);
            Console.WriteLine("Exited method: " + arg.Method.Name);
        }

        public override void OnException(MethodExecutionArgs arg)
        {
            Console.WriteLine("Exception: " + arg.Exception.Message);
        }

    }
}
