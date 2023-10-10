using System.Collections.Generic;

namespace Mov.Core.Commands.Services
{
    /// <summary>
    /// UIのコマンドコントローラー
    /// </summary>
    public class UiCommandController<TService> : IUiController
    {
        #region field

        private readonly TService _service;

        private readonly UiCommandExecuter<TService, UiCommandResponse> _executer;

        #endregion field

        #region constructor

        public UiCommandController(TService service, string endpoint)
        {
            this._service = service;
            _executer = new UiCommandExecuter<TService, UiCommandResponse>(service, endpoint);
        }

        #endregion constructor

        #region method

        public bool Execute()
        {
            return true;
        }

        public bool ExecuteCommand(string command, string[] args)
        {
            _executer.Invoke(command, args);
            return true;
        }

        public IEnumerable<string> GetCommands()
        {
            return _executer.GetCommands();
        }

        public bool ExistsCommand(string command)
        {
            return _executer.Exists(command);
        }

        public virtual string GetCommandHelp()
        {
            return _executer.GetHelp();
        }

        #endregion method
    }
}
