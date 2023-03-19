using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Mov.Loggers.NLogs.Aspects
{
    public static class LogAspect
    {
        private static bool isInitialized = false;

        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public static void LogExecutionTime(MethodBase method, Stopwatch stopwatch)
        {
            Initialize();
            string message = $"Method {method.Name} execution time: {stopwatch.ElapsedMilliseconds} ms";
            logger.Info(message);
        }

        private static void Initialize()
        {
            if (isInitialized) return;
            LogManager.LoadConfiguration("NLog.config");
            isInitialized = true;
        }
    }
}
