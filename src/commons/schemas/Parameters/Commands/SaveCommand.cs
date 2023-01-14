using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Parameters.Commands
{
    public class SaveCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Saving current file");
        }
    }
}
