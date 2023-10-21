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
			public static TimeValue Create(string y, string m, string d)
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
				return new TimeValue(DateTime.ParseExact(setYear + "/" + setMonth + "/" + setDay, DATE_FORMAT, null));
			}
		}

		#endregion constructor

		#region method

		public bool IsEmpty() => this.Value.Equals(Empty);

		/// <summary>
		/// 月の最初の日を求める（DateTime版）
		/// </summary>
		/// <returns>月の初日</returns>
		public DateTime GetFirstDayOfMonth()
		{
			return new DateTime(Value.Year, Value.Month, 1);
		}

		/// <summary>
		/// 月の最後の日を求める（DateTime版）
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
