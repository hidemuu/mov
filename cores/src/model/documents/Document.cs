using Mov.Core.Models;
using System;

namespace Mov.Core.Documents.Models
{
    public sealed class Document : ValueObjectBase<Document>
    {
        #region constant

        /// <summary>
        /// スペース
        /// </summary>
        private const string SPACE = " ";
        /// <summary>
        /// デリミタ
        /// </summary>
        private const char DELIMITER = ',';
        /// <summary>
        /// エスケープ文字
        /// </summary>
        private const string ESCAPE = "/";
        /// <summary>
        /// ヘッダー線文字
        /// </summary>
        private const char HEADER_LINE = '-';

        #endregion constant

        #region property

        public string Value { get; }

        #endregion property

        #region constructor

        public Document(string info)
        {
            Value = info;
        }

        public static Document Empty = new Document(string.Empty);

        public static Document HeaderLine = new Document(HEADER_LINE.ToString());

        #endregion constructor

        #region method

        public bool IsEmpty => Equals(Empty);

        #endregion method

        #region inner method

        protected override bool EqualCore(Document other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion inner method
    }
}