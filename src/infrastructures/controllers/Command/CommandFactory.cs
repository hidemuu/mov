using Mov.Controllers.Command;
using Mov.Utilities.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mov.Controllers
{
    public class CommandFactory<TParameter, TResponse> : ICommandFactory<TParameter, TResponse>
    {
        
        #region フィールド

        private readonly Assembly assembly;
        
        #endregion フィールド

        /// <summary>
        /// コンストラクター
        /// </summary>
        public CommandFactory()
        {
            this.assembly = ReflectionHelper.GetTypeAssembly<TParameter>();
        }

        #region メソッド

        public CommandDictionary<TParameter, TResponse> Create(string endpoint)
        {
            var result = new CommandDictionary<TParameter, TResponse>();
            var types = ReflectionHelper.GetTypesInNamespace(this.assembly, endpoint);
            if (types == null)
            {
                Debug.Assert(false, endpoint);
                return default;
            };
            foreach (var type in types)
            {
                var instance = (ICommand<TParameter, TResponse>)Activator.CreateInstance(type);
                result.Add(instance.Name, instance);
            }
            return result;
        }

        #endregion メソッド

    }
}
