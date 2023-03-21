using MethodBoundaryAspect.Fody.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mov.Controllers.Commands
{
    public sealed class RegisterCommandAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs arg)
        {
            new CommandContext((ICommand)arg.Instance);
            Console.WriteLine("Entered method: " + arg.Method.Name);
        }
    }
}
