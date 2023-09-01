using Mov.Core.Controllers.Services.Commands;
using Mov.Core.Controllers.Services.Commands.UI.Implements;

namespace Mov.Core.Controllers.Services.Commands.UI
{
    public interface IUiCommandFactory<TParameter, TResponse>
    {
        UiCommandDictionary<TParameter, TResponse> Create(string endpoint);
    }
}
