using System;

namespace Mov.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
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
