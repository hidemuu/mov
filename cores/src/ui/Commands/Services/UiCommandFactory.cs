using Mov.Core.Helpers;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Mov.Core.Commands.Services
{
    public class UiCommandFactory<TParameter, TResponse> : IUiCommandFactory<TParameter, TResponse>
    {

        #region field

        private readonly Assembly _assembly;

        #endregion field

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        public UiCommandFactory()
        {
            _assembly = ReflectionHelper.GetTypeAssembly<TParameter>();
        }

        #endregion constructor

        #region method

        public UiCommandDictionary<TParameter, TResponse> Create(string endpoint)
        {
            var result = new UiCommandDictionary<TParameter, TResponse>();
            var types = ReflectionHelper.GetTypesInNamespace(_assembly, endpoint);
            if (types == null || types.Count() == 0)
            {
                Debug.Assert(false, "登録できるコマンドが見つかりません" + Environment.NewLine + endpoint);
                return default;
            };
            try
            {
                foreach (var type in types)
                {
                    var instance = (IUiCommand)Activator.CreateInstance(type);
                    result.Add(instance.Name, instance);
                }
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
            }

            return result;
        }

        #endregion method

    }
}
