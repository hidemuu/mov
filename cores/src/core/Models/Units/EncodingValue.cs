using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Models.Units
{
    public sealed class EncodingValue : ValueObjectBase<EncodingValue>
    {
        #region property

        public int Value { get; }

        #endregion property

        #region constructor

        public EncodingValue()
        {

        }

        #endregion constructor

        #region method

        protected override bool EqualCore(EncodingValue other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }

        #endregion method
    }
}
