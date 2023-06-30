using System;

namespace Mov.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class DisplayTextAttribute : Attribute
    {
        public DisplayTextAttribute(string text)
        {
            Text = text;
        }

        /// <summary>
        /// 表示名称
        /// </summary>
        public string Text { get; }
    }
}
