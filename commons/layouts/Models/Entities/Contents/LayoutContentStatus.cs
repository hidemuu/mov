using Mov.Layouts.Models.Styles;
using Mov.Localizers.Models;
using Mov.Utilities.Models.ValueObjects;

namespace Mov.Layouts.Models.Entities.Contents
{
    public class LayoutContentStatus
    {
        public static LayoutContentStatus Empty = new LayoutContentStatus(
            Info.Empty, IconImage.Empty, VisibilityStyle.Visible, EnableStyle.Enable, Parameter.Empty);

        public Info Name { get; }

        public IconImage Icon { get; }

        public VisibilityStyle Visibility { get; }

        public EnableStyle Enable { get; }

        public Parameter Parameter { get; }

        public LayoutContentStatus(Info name, IconImage icon, VisibilityStyle visibility, EnableStyle isEnable, Parameter parameter)
        {
            Name = name;
            Icon = icon;
            Visibility = visibility;
            Enable = isEnable;
            Parameter = parameter;
        }
    }
}