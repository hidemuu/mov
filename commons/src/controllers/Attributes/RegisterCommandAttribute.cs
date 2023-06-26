using MethodBoundaryAspect.Fody.Attributes;
using Mov.Controllers.Contexts;
using System;

namespace Mov.Controllers.Attributes
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