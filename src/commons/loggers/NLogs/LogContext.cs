using Mov.Loggers.Extensions;
using NLog;
using System;
using System.Diagnostics;
using System.Reflection;

namespace Mov.Loggers.NLogs
{
    public class LogContext
    {
        #region フィールド

        private readonly ILogger logger;

        #endregion フィールド

        #region プロパティ

        private static Lazy<LogContext> instance = new Lazy<LogContext>(() => new LogContext());
        public static LogContext Instance => instance.Value;

        #endregion プロパティ

        #region コンストラクター

        private LogContext()
        {
            logger = LogManager.GetCurrentClassLogger();
            LogManager.LoadConfiguration("NLog.config");
        }

        #endregion コンストラクター

        #region メソッド

        public void LogExecutionTime(MethodBase method, Stopwatch stopwatch)
        {
            string message = method.GetExecutionTimeFormat(stopwatch);
            logger.Trace(message);
        }

        #endregion メソッド
    }
}