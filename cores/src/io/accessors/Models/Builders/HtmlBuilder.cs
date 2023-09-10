using Mov.Core.Models.Connections;

namespace Mov.Core.Models.Networks.Builders
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
            root = new HtmlElement(rootName, string.Empty);
        }

        #endregion constructor

        #region method

        // not fluent
        public void AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
        }

        public HtmlBuilder AddChildFluent(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement(rootName, string.Empty);
        }

        #endregion method

    }
}