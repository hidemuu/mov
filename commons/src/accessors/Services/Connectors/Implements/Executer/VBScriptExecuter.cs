using Mov.Accessors.Services.Connectors.Implements.Processor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Services.Connectors.Implements.Executer
{
    public class VBScriptExecuter : IExecuter
    {
        #region field

        private readonly string filePath;

        private readonly IProcessor processor;

        #endregion field

        #region constructor

        public VBScriptExecuter(string filePath)
        {
            this.filePath = filePath;
            processor = new ShellProcessor("WScript.exe");
        }

        #endregion constructor 

        #region method

        public void Run(string arg)
        {
            arg = !string.IsNullOrEmpty(arg) ? filePath + " " + arg : filePath;
            processor.Run(arg);
            processor.Stop();
        }

        #endregion method
    }
}
