using Mov.Core.Commands.Services;

namespace Mov.Core.Commands
{
    public interface IUiCommandFactory<TParameter, TResponse>
    {
        UiCommandDictionary<TParameter, TResponse> Create(string endpoint);
    }
}
