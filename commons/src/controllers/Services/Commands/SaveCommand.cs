using Mov.Core.Controllers.Attributes;
using System;

namespace Mov.Core.Controllers.Services.Commands
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
