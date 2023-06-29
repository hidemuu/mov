using System.Diagnostics;
using System.Reflection;

namespace Mov.Core.Loggers
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
