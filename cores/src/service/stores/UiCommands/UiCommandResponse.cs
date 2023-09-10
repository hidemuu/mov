using Mov.Core.Models;

namespace Mov.Core.Stores.UiCommands
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
            Value = value;
        }

        public static UiCommandResponse NONE = new UiCommandResponse(RESPONSE_CODE_NONE);

        public static UiCommandResponse SUCCESS = new UiCommandResponse(RESPONSE_CODE_SUCCESS);

        public static UiCommandResponse ERROR = new UiCommandResponse(RESPONSE_CODE_ERROR);

        #endregion constructor

        #region method

        protected override bool EqualCore(UiCommandResponse other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion method
    }
}
