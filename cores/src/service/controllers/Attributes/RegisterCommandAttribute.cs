using MethodBoundaryAspect.Fody.Attributes;
using Mov.Core.Controllers.Contexts;
using Mov.Core.Functions;
using System;

namespace Mov.Core.Controllers.Attributes
{
    public sealed class RegisterCommandAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs arg)
        {
            new CommandContext((IActionCommand)arg.Instance);
            Console.WriteLine("Entered method: " + arg.Method.Name);
        }
    }
}