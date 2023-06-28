using Mov.Layouts.Models.ValueObjects.Contents;
using Mov.Utilities.Models.ValueObjects;
using Mov.Utilities.Models.ValueObjects.Styles;

namespace Mov.Layouts.Models.Entities.Contents
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