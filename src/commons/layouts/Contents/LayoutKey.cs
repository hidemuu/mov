using Mov.Layouts.Contents.ValueObjects;
using Mov.Schemas.Keys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contents
{
    public class LayoutKey
    {
        public static LayoutKey Default = new LayoutKey(CodeKey.Empty, ControlStyle.Label);

        public CodeKey Code { get; }

        public ControlStyle ControlType { get; }


        public LayoutKey(CodeKey code, ControlStyle controlType)
        {
            Code = code;
            ControlType = controlType;
        }

    }
}
