using Mov.Core.Models.ValueObjects;
using Mov.Core.Models.ValueObjects.Layouts;
using Mov.Core.Models.ValueObjects.Styles;

namespace Mov.Core.Layouts.Models.Contents
{
    public class LayoutContentStatus
    {

        #region property

        public Info Name { get; }

        public IconImage Icon { get; }

        public VisibilityStyle Visibility { get; }

        public EnableStyle Enable { get; }

        public Parameter Parameter { get; }

        #endregion property

        #region constructor

        public LayoutContentStatus(Info name, IconImage icon, VisibilityStyle visibility, EnableStyle isEnable, Parameter parameter)
        {
            Name = name;
            Icon = icon;
            Visibility = visibility;
            Enable = isEnable;
            Parameter = parameter;
        }

        public static LayoutContentStatus Empty =>
            new LayoutContentStatus(Info.Empty, IconImage.Empty, VisibilityStyle.Visible, EnableStyle.Enable, Parameter.Empty);

        #endregion constructor
    }
}