using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Mov.Loggers
{
    public interface ILogContext
    {
        /// <summary>
        /// 実行時間をロギングする
        /// </summary>
        /// <param name="method"></param>
        /// <param name="stopwatch"></param>
        void LogExecutionTime(MethodBase method, Stopwatch stopwatch);
    }
}
