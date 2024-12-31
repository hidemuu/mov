using MethodBoundaryAspect.Fody.Attributes;
using Mov.Core.Commands.Contexts;
using System;

namespace Mov.Core.Commands.Attributes
{
    public sealed class RegisterCommandAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs arg)
        {
            new UiCommandContext<string[], string>((IUiCommand<string[], string>)arg.Instance);
            Console.WriteLine("Entered method: " + arg.Method.Name);
        }
    }
}