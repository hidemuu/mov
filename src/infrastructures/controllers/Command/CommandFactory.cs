using Mov.Controllers.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mov.Controllers
{
    public class CommandFactory<TParameter, TResponse> : ICommandFactory<TParameter, TResponse>
    {
        
        #region フィールド

        private readonly string baseName;

        private readonly string baseTypeName;

        #endregion フィールド

        /// <summary>
        /// コンストラクター
        /// </summary>
        public CommandFactory(string baseTypeName)
        {
            this.baseName = this.GetType().Namespace;
            this.baseTypeName = baseTypeName;
        }

        #region メソッド

        public IDictionary<string, ICommand<TParameter, TResponse>> Create()
        {
            var dictionary = new Dictionary<string, ICommand<TParameter, TResponse>>();
            Type type = Type.GetType(baseName + "." + baseTypeName);
            if (type == null)
            {
                Debug.Assert(false, type.FullName);
                return default;
            };
            dictionary.Add(baseTypeName, (ICommand<TParameter, TResponse>)Activator.CreateInstance(type));
            return dictionary;
        }

        #endregion メソッド
    }
}
