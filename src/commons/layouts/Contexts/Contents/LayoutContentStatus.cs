using Mov.Layouts.Contents.ValueObjects;
using Mov.Schemas.Parameters;
using Mov.Schemas.Resources.Images;
using Mov.Schemas.Resources.Localizes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contexts.Contents
{
    public class LayoutContentStatus
    {
        public static LayoutContentStatus Empty = new LayoutContentStatus(LocalString.Empty, IconImage.Empty, VisibilityStyle.Visible, EnableStyle.Enable, Parameter.Empty);

        public LocalString Name { get; }

        public IconImage Icon { get; }

        public VisibilityStyle Visibility { get; }

        public EnableStyle Enable { get; }

        public Parameter Parameter { get; }


        public LayoutContentStatus(LocalString name, IconImage icon, VisibilityStyle visibility, EnableStyle isEnable, Parameter parameter)
        {
            Name = name;
            Icon = icon;
            Visibility = visibility;
            Enable = isEnable;
            Parameter = parameter;
        }

    }
}
