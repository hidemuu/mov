﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Models.Texts
{
    public sealed class FileType : ValueObjectBase<FileType>
    {
        #region constrant

        private const string JSON = "json";

        private const string XML = "xml";

        private const string CSV = "csv";

        #endregion constant

        #region property

        public string Value { get; }

        #endregion property

        #region constructor

        public FileType(string name)
        {
            Value = name;
        }

        public static FileType Json = new FileType(JSON);

        public static FileType Xml = new FileType(XML);

        public static FileType Csv = new FileType(CSV);


        #endregion constructor

        #region method

        public bool IsEmpty() => string.IsNullOrEmpty(Value);

        public bool InNan() => !IsJson() && !IsXml() && !IsCsv();

        public bool IsJson() => Equals(Json);

        public bool IsXml() => Equals(Xml);

        public bool IsCsv() => Equals(Csv);

        protected override bool EqualCore(FileType other)
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