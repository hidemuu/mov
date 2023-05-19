using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.ValueObjects
{
    public sealed class Host : ValueObjectBase<Host>
    {
        #region property

        #endregion property

        #region constructor

        public Host()
        {

        }

        #endregion constructor

        #region protected method

        protected override bool EqualCore(Host other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }

        #endregion protected method
    }
}
