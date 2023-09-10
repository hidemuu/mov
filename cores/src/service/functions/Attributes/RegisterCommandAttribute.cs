using MethodBoundaryAspect.Fody.Attributes;
using Mov.Core.Functions.Commands;
using Mov.Core.Functions.Commands.Contexts;
using System;

namespace Mov.Core.Controllers.Attributes
{
    public sealed class RegisterCommandAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs arg)
        {
            new UiCommandContext((IUiCommand)arg.Instance);
            Console.WriteLine("Entered method: " + arg.Method.Name);
        }
    }
}