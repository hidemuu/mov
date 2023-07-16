using Mov.Core.Models.Networks;

namespace Mov.Core.Templates.Builders
{
    public class HtmlBuilder
    {
        #region field

        private readonly string rootName;

        private HtmlElement root;

        #endregion field

        #region constructor

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            this.root = new HtmlElement(rootName, string.Empty);
        }

        #endregion constructor

        #region method

        // not fluent
        public void AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            this.root.Elements.Add(e);
        }

        public HtmlBuilder AddChildFluent(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            this.root.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return this.root.ToString();
        }

        public void Clear()
        {
            this.root = new HtmlElement(this.rootName, string.Empty);
        }

        #endregion method

    }
}