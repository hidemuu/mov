using System;
using System.Collections.Generic;

namespace Mov.Core.Stores.UiCommands.Contexts
{
    public class UiCommandContext : IDisposable
    {
        public IUiCommand Command;

        private static Stack<UiCommandContext> stack = new Stack<UiCommandContext>();

        public UiCommandContext(IUiCommand command)
        {
            Command = command;
            stack.Push(this);
        }

        public static UiCommandContext Current => stack.Peek();

        public void Dispose()
        {
            // not strictly necessary
            if (stack.Count > 1)
                stack.Pop();
        }
    }
}