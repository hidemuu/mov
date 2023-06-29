using Mov.Core.Layouts.Models.Contents.ValueObjects;
using Mov.Core.Models.ValueObjects.Keys;

namespace Mov.Core.Layouts.Models.Contents.Entities
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
