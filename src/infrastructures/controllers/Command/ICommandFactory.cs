using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Command
{
    public interface ICommandFactory<TParameter, TResponse>
    {
        CommandDictionary<TParameter, TResponse> Create(string endpoint);
    }
}
