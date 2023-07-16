using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Models.Networks
{
    public sealed class HtmlElement : ValueObjectBase<HtmlElement>
    {
        #region constant

        private const int indentSize = 2;

        #endregion constant

        #region property

        public string Name { get; }

        public string Text { get; }

        public List<HtmlElement> Elements { get; } = new List<HtmlElement>();

        #endregion property

        #region constructor

        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Text = text ?? throw new ArgumentNullException(paramName: nameof(text));
        }

        public static HtmlElement Empty = new HtmlElement(string.Empty, string.Empty);

        #endregion constructor

        #region method

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.Append($"{i}<{Name}>\n");
            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.Append(Text);
                sb.Append("\n");
            }

            foreach (var e in Elements)
                sb.Append(e.ToStringImpl(indent + 1));

            sb.Append($"{i}</{Name}>\n");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }

        protected override bool EqualCore(HtmlElement other)
        {
            return this.Name.Equals(other.Name, StringComparison.Ordinal) && this.Text.Equals(other.Text, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return CreateHashCode(this.Name.GetHashCode(), this.Text.GetHashCode());
        }

        #endregion property
    }


}
