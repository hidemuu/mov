using Mov.Core.Loggers.Extensions;
using NLog;
using System;
using System.Diagnostics;
using System.Reflection;

namespace Mov.Core.Loggers.Contexts
{
    public class NLogContext : ILogContext
    {
        #region field

        private readonly ILogger logger;

        #endregion field

        #region constructor

        private NLogContext()
        {
            logger = LogManager.GetCurrentClassLogger();
            LogManager.LoadConfiguration("NLog.config");
        }

        private static Lazy<NLogContext> instance = new Lazy<NLogContext>(() => new NLogContext());
        public static NLogContext Instance => instance.Value;

        #endregion constructor

        #region method

        public void LogExecutionTime(MethodBase method, Stopwatch stopwatch)
        {
            string message = method.GetExecutionTimeFormat(stopwatch);
            logger.Trace(message);
        }

        #endregion method
    }
}