using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Models.Texts
{
    public sealed class DateValue : ValueObjectBase<DateValue>
    {
        #region constant

        private const string FORMAT = "yyyy/MM/dd HH:mm:ss.fff";

        #endregion constant

        #region property

        public DateTime DateTime { get; }

        #endregion property

        #region constructor

        public DateValue(DateTime dateTime)
        {
            this.DateTime = dateTime;
        }

        #endregion constructor

        #region method

        protected override bool EqualCore(DateValue other)
        {
            return DateTime.Equals(other.DateTime);
        }

        protected override int GetHashCodeCore()
        {
            return DateTime.GetHashCode();
        }

        #endregion method
    }
}
