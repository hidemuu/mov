using System;

namespace Mov.Core.Models.Texts
{
    public sealed class Document : ValueObjectBase<Document>
    {

        #region property

        public string Value { get; }

        #endregion property

        #region constructor

        public Document(string info)
        {
            Value = info;
        }

        public static Document Empty = new Document(string.Empty);

        #endregion constructor

        #region method

        public bool IsEmpty => Equals(Empty);

        #endregion method

        #region protected method

        protected override bool EqualCore(Document other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion protected method
    }
}