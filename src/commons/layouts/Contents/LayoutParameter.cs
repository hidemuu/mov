using Mov.Layouts.Contents.ValueObjects;
using Mov.Schemas.Parameters;
using Mov.Schemas.Resources.Images;
using Mov.Schemas.Resources.Localizes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contents
{
    public class LayoutParameter
    {
        public static LayoutParameter Empty = new LayoutParameter(LocalString.Empty, IconImage.Empty, VisibilityStyle.Visible, EnableStyle.Enable, Parameter.Empty);

        public LocalString Name { get; }

        public IconImage Icon { get; }

        public VisibilityStyle Visibility { get; }

        public EnableStyle Enable { get; }

        public Parameter Parameter { get; }


        public LayoutParameter(LocalString name, IconImage icon, VisibilityStyle visibility, EnableStyle isEnable, Parameter parameter)
        {
            Name = name;
            Icon = icon;
            Visibility = visibility;
            Enable = isEnable;
            Parameter = parameter;
        }

    }
}
