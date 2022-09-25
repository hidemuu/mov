using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Command
{
    public interface ICommandFactory<TParameter, TResponse>
    {
        IDictionary<string, ICommand<TParameter, TResponse>> Create();
    }
}
