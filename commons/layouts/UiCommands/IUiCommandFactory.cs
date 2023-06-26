using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Command
{
    public interface IUiCommandFactory<TParameter, TResponse>
    {
        UiCommandDictionary<TParameter, TResponse> Create(string endpoint);
    }
}
