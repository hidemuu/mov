using Mov.Core.Models;
using Mov.Core.Styles.Models;

namespace Mov.Core.Layouts.Models.Contents
{
    public class LayoutContentKey
    {
        public static LayoutContentKey Default = new LayoutContentKey(
            Identifier<string>.Empty, ControlStyle.Label);

        public Identifier<string> Code { get; }

        public ControlStyle ControlType { get; }


        public LayoutContentKey(Identifier<string> code, ControlStyle controlType)
        {
            Code = code;
            ControlType = controlType;
        }

    }
}
