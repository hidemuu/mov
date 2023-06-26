using System;
using System.Collections.Generic;
using System.Text;

namespace Schedulers.Models
{
    public class Schedule
    {
        #region プロパティ

        public int Number { get; set; } = 0;
        public string Name { get; set; } = "";
        public DateTime StartTime { get; set; } = DateTime.MaxValue;
        public DateTime StopTime { get; set; } = DateTime.MaxValue;
        public ScheduleStatus Status { get; set; } = ScheduleStatus.Standby;

        public bool IsUse { get; set; } = true;

        #endregion プロパティ

        #region メソッド

        public void SetStartStopTime(string startTimeString, string stopTimeString, double offsetStartDay = 0, double offsetStopDay = 0)
        {
            SetStartTime(startTimeString, offsetStartDay);
            SetStopTime(stopTimeString, offsetStopDay);
        }
        public void SetStartTime(string setTimeString, double offsetDay = 0)
        {
            StartTime = SetTime(setTimeString, offsetDay);
        }
        public void SetStartTime(DateTime dateTime)
        {
            StartTime = dateTime;
        }
        public void SetStopTime(string setTimeString, double offsetDay = 0)
        {
            StopTime = SetTime(setTimeString, offsetDay);
        }
        public void SetStopTime(DateTime dateTime)
        {
            StopTime = dateTime;
        }
        public void SetStatus(ScheduleStatus status)
        {
            Status = status;
        }
        public void SetUse(bool isUse)
        {
            IsUse = isUse;
        }

        public object Clone()
        {
            return new Schedule(); //同じものを複製する
        }

        #endregion メソッド

        #region 内部メソッド

        private DateTime SetTime(string setTimeString, double offsetDay = 0)
        {
            if (setTimeString == "")
            {
                return DateTime.MaxValue;
            }

            var result = DateTime.ParseExact(DateTime.Today.ToString("yyyy/MM/dd " + setTimeString + ":00"), "yyyy/MM/dd HH:mm:ss", null);
            result = result.AddDays(offsetDay);
            return result;
        }
        private DateTime ConvertIntToDateTime(int hour, int minute)
        {
            if (minute > 59)
            {
                hour += 1;
            }

            var day = DateTime.Today;
            if (DateTime.Today.Hour > hour)
            {
                day.AddDays(1);
            }
            else if (hour > 23)
            {
                day.AddDays(1);
                hour -= 24;
            }

            return ConvertStringToDateTime(day, hour.ToString(), minute.ToString());

        }
        private DateTime ConvertStringToDateTime(DateTime day, string hourString, string minuteString)
        {
            if (hourString.Length == 1)
            {
                hourString = "0" + hourString;
            }
            if (minuteString.Length == 1)
            {
                minuteString = "0" + minuteString;
            }

            return DateTime.ParseExact(day.ToString("yyyy/MM/dd " + hourString + ":" + minuteString + ":00"), "yyyy/MM/dd HH:mm:ss", null);
        }

        public void GetHourMinuteString(string hourMinuteString, out string hour, out string minute)
        {
            var timeAry = hourMinuteString.Split(":".ToCharArray());
            hour = timeAry[0];
            minute = timeAry[1];
        }
        public int GetHour(string hourString)
        {
            if (hourString.Length == 2)
            {
                if (hourString.Substring(0, 1) == "0")
                {
                    hourString = hourString.Substring(1, 1);
                }
            }
            if (!int.TryParse(hourString, out int hour)) { hour = 23; };
            return hour;
        }
        public int GetMinute(string minuteString)
        {
            if (minuteString.Length == 2)
            {
                if (minuteString.Substring(0, 1) == "0")
                {
                    minuteString = minuteString.Substring(1, 1);
                }
            }
            if (!int.TryParse(minuteString, out int minute)) { minute = 0; };
            return minute;
        }

        #endregion 内部メソッド

    }
}
