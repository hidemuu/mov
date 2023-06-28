using Mov.Layouts.Models.ValueObjects;
using Mov.Utilities.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Models.Entities.Contents
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
