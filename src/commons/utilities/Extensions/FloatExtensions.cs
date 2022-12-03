using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Helper
{
    /// <summary>
    /// float型の拡張処理
    /// </summary>
    public static class FloatExtensions
    {
        #region 拡張メソッド

        /// <summary>
        /// 小数点以下を指定桁数で四捨五入
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPoint"></param>
        /// <returns></returns>
        public static string RoundString(this float value, int decimalPoint)
        {
            var val = Convert.ToSingle(Math.Round(value, decimalPoint));
            return val.ToString("F" + decimalPoint);
        }

        #endregion 拡張メソッド
    }
}
