using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Connectors
{
    public interface IProcessor
    {
        /// <summary>
        /// プロセスを実行する
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        string Run(string args);

        /// <summary>
        /// プロセスを停止する
        /// </summary>
        void Stop();
    }
}
