using Mov.Core.Contexts.Layouts.ValueObjects;
using Mov.Core.Models.Keys;

namespace Mov.Core.Layouts.Models.Contents
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
