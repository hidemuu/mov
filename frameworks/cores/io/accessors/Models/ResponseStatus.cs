using Mov.Core.Models;

namespace Mov.Core.Accessors.Models
{
    public sealed class ResponseStatus : ValueObjectBase<ResponseStatus>
    {
        #region property

        public int Code { get; }

        #endregion property

        #region constructor

        public ResponseStatus(int code)
        {
            Code = code;
        }

        public static ResponseStatus Empty = new ResponseStatus(0);

        public static ResponseStatus Success = new ResponseStatus(200);

        public static ResponseStatus ClientError = new ResponseStatus(400);

        public static ResponseStatus ServerError = new ResponseStatus(500);

        #endregion constructor

        #region method

        public bool IsSuccess()
        {
            return this.Equals(Success);
        }

        #endregion method

        #region inner method

        protected override bool EqualCore(ResponseStatus other)
        {
            return Code.Equals(other.Code);
        }

        protected override int GetHashCodeCore()
        {
            return Code.GetHashCode();
        }

        #endregion inner method
    }
}