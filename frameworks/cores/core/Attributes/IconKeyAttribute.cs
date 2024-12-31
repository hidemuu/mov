using System;

namespace Mov.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class IconKeyAttribute : Attribute
    {
        public IconKeyAttribute(string key)
        {
            Key = key;
        }

        /// <summary>
        /// 表示名称
        /// </summary>
        public string Key { get; }
    }
}
