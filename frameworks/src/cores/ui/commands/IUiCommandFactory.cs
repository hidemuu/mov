using Mov.Core.Commands.Services;

namespace Mov.Core.Commands
{
    public interface IUiCommandFactory<TRequest, TResponse>
    {
        UiCommandCollection<TRequest, TResponse> Create(string endpoint, params object[] args);
    }
}
