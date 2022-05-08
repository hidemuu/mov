using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Converter
{
    public static class DateTimeConverter
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
        /// <summary>
        /// 年月日文字列から、日付フォーマット(yyyy/MM/dd)に従いDateTime型で出力
        /// </summary>
        /// <param name="y">年文字列</param>
        /// <param name="m">月文字列</param>
        /// <param name="d">日文字列</param>
        /// <returns>フォーマット変換結果</returns>
        public static DateTime MakeDateYYYYMMDD(string y, string m, string d)
        {
            string setYear = y;
            string setMonth = m;
            string setDay = d;
            if (setMonth.Length == 1)
            {
                setMonth = "0" + setMonth;
            }
            if (setDay.Length == 1)
            {
                setDay = "0" + setDay;
            }
            return DateTime.ParseExact(setYear + "/" + setMonth + "/" + setDay, "yyyy/MM/dd", null);
        }
        /// <summary>
        /// 日付を分単位に変換しint型で出力
        /// </summary>
        /// <param name="date">変換対象日付</param>
        /// <param name="startDate">立上げ時日付（日跨ぎ判定用）</param>
        /// <returns>変換結果</returns>
        public static int ConvertDateToMinute(DateTime date, DateTime startDate)
        {
            int buf = date.Hour * 60 + date.Minute;
            int over = 0;
            if (date.Day > startDate.Day) over = 1;
            int result = buf - (over * 24) * 60;  //日跨ぎ処理
            if (result < 0) { result = buf; }   //結果がマイナスなら日跨ぎ無視
            return result;
        }
        /// <summary>
        /// 時分を分単位に変換しint型で出力
        /// </summary>
        /// <param name="hour">時(int型)</param>
        /// <param name="minute">分(int型)</param>
        /// <param name="over">日跨ぎ数(int型)</param>
        /// <returns>変換結果</returns>
        public static int ConvertHourToMinute(int hour, int minute, int over)
        {
            int buf = hour * 60 + minute;
            int result = buf - (over * 24) * 60;  //日跨ぎ処理
            if (result < 0) { result = buf; }   //結果がマイナスなら日跨ぎ無視
            return result;
        }
        /// <summary>
        /// 時刻フォーマット文字列「**:**」を分単位に換算(int型)
        /// </summary>
        /// <param name="time">文字列「**:**」</param>
        /// <returns>変換結果</returns>
        public static int ConvertTimeStringToMinute(string time)
        {
            //時抽出
            string bufHour = time.Substring(0, 2);
            if (bufHour.Length == 2 && bufHour.Substring(0, 1) == "0")
            {
                bufHour = bufHour.Substring(1, 1);
            }
            int hour = int.Parse(bufHour);
            //分抽出
            string bufMin = time.Substring(3, 2);
            if (bufMin.Length == 2 && bufMin.Substring(0, 1) == "0")
            {
                bufMin = bufMin.Substring(1, 1);
            }
            int minute = int.Parse(bufMin);
            //分単位変換
            return ConvertHourToMinute(hour, minute, 0);
        }
        /// <summary>
        /// 分単位を日付フォーマット文字列「**:**」に変換
        /// </summary>
        /// <param name="minute">分単位の数値</param>
        /// <param name="over">日跨ぎ数</param>
        /// <returns>変換結果「**:**」</returns>
        public static string ConvertMinuteToTimeString(int minute, int over)
        {
            string result = "";
            int bufMinute = minute;
            //日跨ぎ分処理
            if (over > 0) { bufMinute -= (over * 24) * 60; }
            //時,分換算
            int h = bufMinute / 60;
            int m = bufMinute - (h * 60);
            //文字列生成
            string hStr = h.ToString();
            string mStr = m.ToString();
            if (hStr.Length == 1) { hStr = "0" + hStr; }
            if (mStr.Length == 1) { mStr = "0" + mStr; }
            result = hStr + ":" + mStr;
            return result;
        }

        /// <summary>
        /// 日跨ぎ日数の取得（１月以上違っていたら、固定値30を返す）
        /// </summary>
        /// <param name="dt1">比較元DateTime</param>
        /// <param name="dt2">比較先DateTime</param>
        /// <returns>変換結果</returns>
        public static int GetOverDate(DateTime dt1, DateTime dt2)
        {
            if (dt1.Date == dt2.Date) { return 0; }
            else if (dt1.Year == dt2.Year && dt1.Month == dt2.Month) { return dt2.Day - dt1.Day; }
            else { return 30; }
        }
    }
}
