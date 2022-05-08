using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mov.Utilities.Processor
{
    public abstract class TextFileProcessor
    {
        public static void Run<T>(string fileName) where T : TextFileProcessor, new()
        {
            var self = new T();
            self.Process(fileName);
        }

        private void Process(string fileName)
        {
            Initialize(fileName);
            using (var sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Execute(line);
                }
            }
            Terminate();
        }

        protected virtual void Initialize(string fname) { }
        protected virtual void Execute(string line) { }
        protected virtual void Terminate() { }
    }
}
