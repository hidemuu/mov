using Mov.Controllers.Commands;
using Mov.Schemas.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Commands
{
    public class CommandContext : IDisposable
    {
        public ICommand Command;

        private static Stack<CommandContext> stack = new Stack<CommandContext>();

        public CommandContext(ICommand command)
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
