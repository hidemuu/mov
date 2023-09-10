using Mov.Core.Controllers.Attributes;
using System;

namespace Mov.Core.Functions.Commands.Actions
{
    [RegisterCommand]
    public class OpenCommand : IActionCommand
    {
        public string Name => throw new NotImplementedException();

        public string ShortName => throw new NotImplementedException();

        public void Execute()
        {
            Console.WriteLine("Opening a file");
        }
    }
}
