using MethodBoundaryAspect.Fody.Attributes;
using Mov.Core.Loggers.Contexts;
using System;
using System.Diagnostics;

namespace Mov.Core.Loggers.Attributes
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
            NLogContext.Instance.LogExecutionTime(arg.Method, stopwatch);
            Console.WriteLine("Exited method: " + arg.Method.Name);
        }

        public override void OnException(MethodExecutionArgs arg)
        {
            Console.WriteLine("Exception: " + arg.Exception.Message);
        }

    }
}
