using System;
using System.Collections.Generic;
using Mov.Core.Functions;

namespace Mov.Core.Controllers.Contexts
{
    public class CommandContext : IDisposable
    {
        public IActionCommand Command;

        private static Stack<CommandContext> stack = new Stack<CommandContext>();

        public CommandContext(IActionCommand command)
        {
            Command = command;
            stack.Push(this);
        }

        public static CommandContext Current => stack.Peek();

        public void Dispose()
        {
            // not strictly necessary
            if (stack.Count > 1)
                stack.Pop();
        }
    }
}