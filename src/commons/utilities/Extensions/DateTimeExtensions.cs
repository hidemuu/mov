using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 月の最初の日を求める（DateTime版）
        /// </summary>
        /// <param name="theDay">変換元日付型データ</param>
        /// <returns>月の初日</returns>
        public static DateTime GetFirstDayOfMonth(this DateTime theDay)
        {
            return new DateTime(theDay.Year, theDay.Month, 1);
        }

        /// <summary>
        /// 月の最後の日を求める（DateTime版）
        /// </summary>
        /// <param name="theDay">変換元日付型データ</param>
        /// <returns>月の最終日</returns>
        public static DateTime GetLastDayOfMonth(this DateTime theDay)
        {
            int days = DateTime.DaysInMonth(theDay.Year, theDay.Month);
            return new DateTime(theDay.Year, theDay.Month, days);
        }
    }
}
