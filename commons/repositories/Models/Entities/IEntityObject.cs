using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Repositories.Models.EntityObjects
{
    public interface IEntityObject
    {
        #region メソッド

        string[] GetContentStrings();

        string[] GetHeaderStrings();

        /// <summary>
        ///ヘッダー文字列取得
        /// </summary>
        /// <returns></returns>
        string ToHeaderString();

        /// <summary>
        ///コンテンツ文字列取得
        /// </summary>
        /// <returns></returns>
        string ToContentString();

        #endregion メソッド

    }
}
