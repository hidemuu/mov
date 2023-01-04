using Mov.Schemas.Elements.Parameters;
using Mov.Schemas.Elements.Resources.Images;
using Mov.Schemas.Elements.Resources.Localizes;
using Mov.Schemas.Elements.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contexts.Contents
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
