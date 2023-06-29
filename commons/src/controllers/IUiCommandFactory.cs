using Mov.Core.Controllers.Services.Commands;

namespace Mov.Core.Controllers
{
    public interface IUiCommandFactory<TParameter, TResponse>
    {
        UiCommandDictionary<TParameter, TResponse> Create(string endpoint);
    }
}
