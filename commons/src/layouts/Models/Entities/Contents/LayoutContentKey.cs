using Mov.Layouts.Models.ValueObjects.Contents;
using Mov.Utilities.Models.ValueObjects.Keys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Models.Entities.Contents
{
    public class LayoutContentKey
    {
        public static LayoutContentKey Default = new LayoutContentKey(
            CodeKey.Empty, ControlStyle.Label);

        public CodeKey Code { get; }

        public ControlStyle ControlType { get; }


        public LayoutContentKey(CodeKey code, ControlStyle controlType)
        {
            Code = code;
            ControlType = controlType;
        }

    }
}
