using Mov.Core.Layouts.Models.Styles;
using Mov.Core.Models.Identifiers;

namespace Mov.Core.Layouts.Models.Contents
{
    public class LayoutContentKey
    {
        public static LayoutContentKey Default = new LayoutContentKey(
            IdentifierCode.Empty, ControlStyle.Label);

        public IdentifierCode Code { get; }

        public ControlStyle ControlType { get; }


        public LayoutContentKey(IdentifierCode code, ControlStyle controlType)
        {
            Code = code;
            ControlType = controlType;
        }

    }
}
