using MethodBoundaryAspect.Fody.Attributes;
using Mov.Core.Stores.UiCommands;
using Mov.Core.Stores.UiCommands.Contexts;
using System;

namespace Mov.Core.Stores.Attributes
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