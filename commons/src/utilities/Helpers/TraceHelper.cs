using System;

namespace Mov.Core.Helpers
{
    /// <summary>
    /// 検索処理のヘルパークラス
    /// </summary>
    public static class TraceHelper
    {
        private static int level = 0;

        /// <summary>
        /// 再帰呼び出し過程を追跡出力する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="frame"></param>
        /// <param name="args"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T Trace<T>(string frame, string[] args, Func<T> func)
        {
            var s = new string(new char[level]).Replace("\0", "- ") + level + ": " + frame;
            Console.WriteLine(s + " (" + string.Join(",", args) + ")");
            level++;
            var ret = func();
            level--;
            Console.WriteLine(s + " =" + ret);
            return ret;
        }
    }
}
