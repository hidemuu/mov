using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class LanguageKeyAttribute : Attribute
    {
        public LanguageKeyAttribute(string key)
        {
            Key = key;
        }

        /// <summary>
        /// 表示名称
        /// </summary>
        public string Key { get; }
    }
}
