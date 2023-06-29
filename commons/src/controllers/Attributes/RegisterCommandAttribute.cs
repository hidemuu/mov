using MethodBoundaryAspect.Fody.Attributes;
using Mov.Core.Controllers.Contexts;
using System;

namespace Mov.Core.Controllers.Attributes
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