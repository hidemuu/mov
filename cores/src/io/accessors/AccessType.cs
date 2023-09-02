using Mov.Core.Models;
using Mov.Core.Models.Texts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Accessors
{
    public sealed class AccessType : ValueObjectBase<AccessType>
    {
        #region property

        public string Value { get; }

        #endregion property

        #region constructor

        private AccessType(string type)
        {
            Value = type;
        }

        public static AccessType Json => new AccessType("json");

        public static AccessType Xml => new AccessType("xml");

        public static AccessType Csv => new AccessType("csv");

        public static AccessType Http => new AccessType("http");

        public static AccessType Create(FileType fileType)
        {
            if (fileType.IsCsv()) return Csv;
            else if (fileType.IsXml()) return Xml;
            else if (fileType.IsJson()) return Json;
            else if (fileType.IsDb()) return Http;
            else throw new ArgumentException();
        }

        #endregion constructor

        #region method

        public bool IsJson() => Equals(Json);

        public bool IsXml() => Equals(Xml);

        public bool IsCsv() => Equals(Csv);

        public bool IsHttp() => Equals(Http);

        public bool IsFile() => IsJson() || IsXml() || IsCsv();

        public bool IsWeb() => IsHttp();

        protected override bool EqualCore(AccessType other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion method
    }
}
