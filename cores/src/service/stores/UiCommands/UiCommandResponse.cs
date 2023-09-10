using Mov.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Functions.Commands
{
    public sealed class UiCommandResponse : ValueObjectBase<UiCommandResponse>
    {
        #region field

        private const int RESPONSE_CODE_NONE = -1;

        private const int RESPONSE_CODE_SUCCESS = 200;

        private const int RESPONSE_CODE_ERROR = 400;

        #endregion field

        #region property

        public int Value { get; }

        #endregion property

        #region constructor

        public UiCommandResponse(int value) 
        {
            this.Value = value;
        }

        public static UiCommandResponse NONE = new UiCommandResponse(RESPONSE_CODE_NONE);

        public static UiCommandResponse SUCCESS = new UiCommandResponse(RESPONSE_CODE_SUCCESS);

        public static UiCommandResponse ERROR = new UiCommandResponse(RESPONSE_CODE_ERROR);

        #endregion constructor

        #region method

        protected override bool EqualCore(UiCommandResponse other)
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
