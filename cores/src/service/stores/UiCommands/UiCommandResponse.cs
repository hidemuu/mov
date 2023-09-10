using Mov.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Functions.Commands
{
    public sealed class UiCommandResponse : ValueObjectBase<UiCommandResponse>
    {
        #region property

        public string Value { get; }

        #endregion property

        #region constructor

        public UiCommandResponse(string value) 
        {
            this.Value = value;
        }

        #endregion constructor

        #region method

        protected override bool EqualCore(UiCommandResponse other)
        {
            return this.Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }

        #endregion method
    }
}
