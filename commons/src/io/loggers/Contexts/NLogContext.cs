using Mov.Core.Loggers.Extensions;
using NLog;
using System;
using System.Diagnostics;
using System.Reflection;

namespace Mov.Core.Loggers.Contexts
{
    public class NLogContext : ILogContext
    {
        #region フィールド

        private readonly ILogger logger;

        #endregion フィールド

        #region プロパティ

        private static Lazy<NLogContext> instance = new Lazy<NLogContext>(() => new NLogContext());
        public static NLogContext Instance => instance.Value;

        #endregion プロパティ

        #region コンストラクター

        private NLogContext()
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