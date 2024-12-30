using System;
using System.Collections.Generic;

namespace Mov.Core.Commands.Contexts
{
    public class UiCommandContext<TRequest, TResponse> : IDisposable
    {
        public IUiCommand<TRequest, TResponse> Command;

        private static Stack<UiCommandContext<TRequest, TResponse>> stack = new Stack<UiCommandContext<TRequest, TResponse>>();

        public UiCommandContext(IUiCommand<TRequest, TResponse> command)
        {
            Command = command;
            stack.Push(this);
        }

        public static UiCommandContext<TRequest, TResponse> Current => stack.Peek();

        public void Dispose()
        {
            // not strictly necessary
            if (stack.Count > 1)
                stack.Pop();
        }
    }
}