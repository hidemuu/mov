using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Parameters.Commands
{
    public class OpenCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Opening a file");
        }
    }
}
