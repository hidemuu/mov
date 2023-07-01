using System;
using System.Net;

namespace Mov.Core.Models.Units
{
    /// <summary>
    /// IPアドレスのValueObject
    /// </summary>
    public sealed class IpAddressUnit : ValueObjectBase<IpAddressUnit>
    {
        #region プロパティ

        public string Value { get; }

        public IPAddress IpAddress { get; }

        #endregion プロパティ

        #region コンストラクター

        public IpAddressUnit(string ip)
        {
            Value = ip;
            if (!IPAddress.TryParse(ip, out IPAddress ipAddress))
            {
                IpAddress = IPAddress.None;
                throw new ArgumentException();
            }
            IpAddress = ipAddress;
        }

        #endregion コンストラクター

        #region メソッド

        public bool IsEmpty() => IpAddress.Equals(IPAddress.None);

        #endregion メソッド

        #region 内部メソッド

        protected override bool EqualCore(IpAddressUnit other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion 内部メソッド
    }
}