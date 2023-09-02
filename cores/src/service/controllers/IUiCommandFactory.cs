using Mov.Core.Functions.Commands.UI;

namespace Mov.Core.Functions
{
    public interface IUiCommandFactory<TParameter, TResponse>
    {
        UiCommandDictionary<TParameter, TResponse> Create(string endpoint);
    }
}
