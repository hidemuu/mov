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
            if (types == null || types.Count() == 0)
            {
                Debug.Assert(false, "登録できるコマンドが見つかりません" + Environment.NewLine + endpoint);
                return default;
            };
            try
            {
                foreach (var type in types)
                {
                    var instance = (ICommand<TParameter, TResponse>)Activator.CreateInstance(type);
                    result.Add(instance.Name, instance);
                }
            }
            catch(Exception ex)
            {
                Debug.Assert(false, ex.Message);
            }
           
            return result;
        }

        #endregion メソッド

    }
}
