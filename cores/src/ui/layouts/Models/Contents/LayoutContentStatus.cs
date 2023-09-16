using Mov.Core.Models;
using Mov.Core.Styles.Models;

namespace Mov.Core.Layouts.Models.Contents
{
    public class LayoutContentStatus
    {

        #region property

        public Document Name { get; }

        public IconImage Icon { get; }

        public VisibilityStyle Visibility { get; }

        public EnableStyle Enable { get; }

        public Parameter Parameter { get; }

        #endregion property

        #region constructor

        public LayoutContentStatus(Document name, IconImage icon, VisibilityStyle visibility, EnableStyle isEnable, Parameter parameter)
        {
            Name = name;
            Icon = icon;
            Visibility = visibility;
            Enable = isEnable;
            Parameter = parameter;
        }

        public static LayoutContentStatus Empty =>
            new LayoutContentStatus(Document.Empty, IconImage.Empty, VisibilityStyle.Visible, EnableStyle.Enable, Parameter.Empty);

        #endregion constructor
    }
}