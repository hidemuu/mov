using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Command
{
    public abstract class CommandHandlerBase<T> : ICommandHandler<T>
    {
        protected abstract IDictionary<string, ICommand<T>> Handler { get; }

        private readonly T parameter;
        public CommandHandlerBase(T parameter)
        {
            this.parameter = parameter;
        }

        public Response Invoke(string command)
        {
            return Handler[command].Invoke(this.parameter);
        }
    }
}
