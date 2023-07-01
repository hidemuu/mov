using Mov.Core.Controllers.Attributes;
using System;

namespace Mov.Core.Controllers.Services.Commands
{
    [RegisterCommand]
    public class OpenCommand : ICommand
    {
        public string Name => throw new NotImplementedException();

        public string ShortName => throw new NotImplementedException();

        public void Execute()
        {
            Console.WriteLine("Opening a file");
        }
    }
}
