using Mov.Core.Learnings.Models;
using Mov.Core.Models;
using Mov.Core.Models.Styles;

namespace Mov.Core.Layouts.Models.Contents
{
    public class LayoutContentValue
    {
        #region property

        public LayoutValue Schema { get; }

        public Variable Variable { get; }

        public Macro Macro { get; }

        #endregion property

        #region constructor

        public LayoutContentValue(LayoutValue schema, Variable variable, Macro macro)
        {
            Schema = schema;
            Variable = variable;
            Macro = macro;
        }

        public static LayoutContentValue Empty =>
            new LayoutContentValue(LayoutValue.Empty, Variable.Empty, Macro.Empty);

        #endregion constructor

    }
}
