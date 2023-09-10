using Mov.Core.Stores.UiCommands.Implements;

namespace Mov.Core.Stores.UiCommands
{
    public interface IUiCommandFactory<TParameter, TResponse>
    {
        UiCommandDictionary<TParameter, TResponse> Create(string endpoint);
    }
}
