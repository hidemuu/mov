using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Connectors
{
    public interface IProcessor
    {
        /// <summary>
        /// 実行
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        string Run(string fileName, string args);
    }
}
