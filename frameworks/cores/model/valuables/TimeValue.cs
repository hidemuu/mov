using Mov.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Valuables
{
	public sealed class TimeValue : ValueObjectBase<TimeValue>
	{
		#region constant

		private const string DATE_FORMAT = "yyyy/MM/dd";

		private const string DATE_FORMAT_JA = "ggyy年M月d日";

		private const string DATETIME_FORMAT = "yyyy/MM/dd HH:mm:ss";

		#endregion constant

		#region property

		public DateTime Value { get; }

		#endregion property

		#region constructor

		public TimeValue(DateTime dateTime)
		{
			this.Value = dateTime;
		}

		public static TimeValue Empty { get; } = new TimeValue(DateTime.MinValue);

		public static class Factory
		{
			public static TimeValue Create(string dateTime)
			{
				return new TimeValue(DateTime.Parse(dateTime));
			}

			public static TimeValue CreateByDate(string y, string m, string d)
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
				return new TimeValue(DateTime.ParseExact($@"{setYear}/{setMonth}/{setDay}", DATE_FORMAT, null));
			}

			public static TimeValue CreateByDate(int year, int month, int day)
			{
				return new TimeValue(new DateTime(year, month, day));
			}

			public static TimeValue CreateByDate(int date)
			{
				int year = date / 10000;
				int month = (date / 100) % 100;
				int day = (date % 100);
				return new TimeValue(new DateTime(year, month, day));
			}
		}

		#endregion constructor

		#region method

		public bool IsEmpty() => this.Value.Equals(Empty);

		public string ToStringDate()
		{
			return this.Value.ToString(DATE_FORMAT);
		}

		public string ToStringJapaneseDate()
		{
			System.Globalization.CultureInfo Info = new System.Globalization.CultureInfo("ja-JP");
			Info.DateTimeFormat.Calendar = new System.Globalization.JapaneseCalendar();
			return this.Value.ToString(DATE_FORMAT_JA);
		}

		public string ToStringDateTime()
		{
			return this.Value.ToString(DATETIME_FORMAT);
		}

		public int ToIntDate()
		{
			return int.TryParse(this.Value.ToString(DATE_FORMAT), out int result) ? result : 0;
		}

		public int ToIntDateTime()
		{
			return int.TryParse(this.Value.ToString(DATETIME_FORMAT), out int result) ? result : 0;
		}

		/// <summary>
		/// 月の最初の日を求める
		/// </summary>
		/// <returns>月の初日</returns>
		public DateTime GetFirstDayOfMonth()
		{
			return new DateTime(Value.Year, Value.Month, 1);
		}

		/// <summary>
		/// 月の最後の日を求める
		/// </summary>
		/// <returns>月の最終日</returns>
		public DateTime GetLastDayOfMonth()
		{
			int days = DateTime.DaysInMonth(Value.Year, Value.Month);
			return new DateTime(Value.Year, Value.Month, days);
		}

		protected override bool EqualCore(TimeValue other)
		{
			return this.Value.Equals(other.Value);
		}

		protected override int GetHashCodeCore()
		{
			return this.Value.GetHashCode();
		}

		#endregion method
	}
}
