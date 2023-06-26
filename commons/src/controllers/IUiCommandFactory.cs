using System;
using System.Collections.Generic;
using System.Text;
using Mov.Controllers.Services.Commands;

namespace Mov.Controllers
{
    public interface IUiCommandFactory<TParameter, TResponse>
    {
        UiCommandDictionary<TParameter, TResponse> Create(string endpoint);
    }
}
