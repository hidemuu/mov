using System.Collections.Generic;

namespace Mov.Core.Commands.Services
{
    /// <summary>
    /// 登録コマンドのコレクション
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <remarks>
    /// Key : コマンド名
    /// Value : コマンドのインスタンス
    /// </remarks>
    public class UiCommandCollection<TRequest, TResponse>
    {
        #region field

        private readonly ICollection<IUiCommand<TRequest, TResponse>> _commands;

        #endregion field

        #region constructor

        public UiCommandCollection()
        {
            _commands = new HashSet<IUiCommand<TRequest, TResponse>>();

		}


		#endregion constructor

		#region method

        public void Add(IUiCommand<TRequest, TResponse> command)
        {
            _commands.Add(command);
        }

        public IEnumerable<IUiCommand<TRequest, TResponse>> GetAll()
        {
            return _commands;
        }

        public IUiCommand<TRequest, TResponse> Get(string name)
        {
            foreach(var command in _commands)
            {
                if(command.Name.Equals(name) || command.ShortName.Equals(name))
                {
                    return command;
                }
            }
            return null;
        }

        public bool Exists(string name)
        {
			foreach (var command in _commands)
			{
				if (command.Name.Equals(name) || command.ShortName.Equals(name))
				{
					return true;
				}
			}
			return false;
		}

		#endregion method
	}
}
