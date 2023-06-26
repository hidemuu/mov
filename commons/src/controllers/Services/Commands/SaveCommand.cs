using Mov.Controllers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Services.Commands
{
    [RegisterCommand]
    public class SaveCommand : ICommand
    {
        public string Name => throw new NotImplementedException();

        public string ShortName => throw new NotImplementedException();

        public void Execute()
        {
            Console.WriteLine("Saving current file");
        }
    }
}
