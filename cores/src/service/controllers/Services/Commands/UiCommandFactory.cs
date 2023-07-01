using Mov.Core.Helpers;
using Mov.Core.Templates.Controllers;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Mov.Core.Controllers.Services.Commands
{
    public class UiCommandFactory<TParameter, TResponse> : IUiCommandFactory<TParameter, TResponse>
    {

        #region フィールド

        private readonly Assembly assembly;

        #endregion フィールド

        /// <summary>
        /// コンストラクター
        /// </summary>
        public UiCommandFactory()
        {
            assembly = ReflectionHelper.GetTypeAssembly<TParameter>();
        }

        #region メソッド

        public UiCommandDictionary<TParameter, TResponse> Create(string endpoint)
        {
            var result = new UiCommandDictionary<TParameter, TResponse>();
            var types = ReflectionHelper.GetTypesInNamespace(assembly, endpoint);
            if (types == null || types.Count() == 0)
            {
                Debug.Assert(false, "登録できるコマンドが見つかりません" + Environment.NewLine + endpoint);
                return default;
            };
            try
            {
                foreach (var type in types)
                {
                    var instance = (IUiCommand<TParameter, TResponse>)Activator.CreateInstance(type);
                    result.Add(instance.Name, instance);
                }
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
            }

            return result;
        }

        #endregion メソッド

    }
}
