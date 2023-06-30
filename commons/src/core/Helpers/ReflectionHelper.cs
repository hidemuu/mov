using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Mov.Core.Helpers
{
    /// <summary>
    /// リフレクション処理のヘルパークラス
    /// </summary>
    public static class ReflectionHelper
    {
        /// <summary>
        /// 指定型が存在するアセンブリを取得する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Assembly GetTypeAssembly<T>()
        {
            return Assembly.GetAssembly(typeof(T)); ;
        }

        public static Assembly GetBaseTypeAssembly<T>()
        {
            var type = typeof(T);
            if (!type.IsInterface)
            {
                type = type?.GetInterfaces()?.FirstOrDefault() ?? type;
            }
            return Assembly.GetAssembly(type);
        }

        /// <summary>
        /// 指定アセンブリの指定名前空間のType一覧を取得する
        /// </summary>
        /// <param name="assembly">アセンブリ</param>
        /// <param name="endpoint">名前空間</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypesInNamespace(Assembly assembly, string endpoint)
        {
            var assemblyName = assembly.GetName().Name;
            var name_space = assemblyName + "." + endpoint;
            try
            {
                var types = assembly.GetTypes();
                return
                  types.Where(t => string.Equals(t.Namespace, name_space, StringComparison.Ordinal));
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
            }
            return null;
        }
    }
}
