using Mov.Layouts.Contents.ValueObjects;
using Mov.Schemas.Bodies;
using Mov.Schemas.Parameters;
using Mov.Schemas.Resources.Macros;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contents
{
    public class LayoutValue
    {
        public static LayoutValue Empty = new LayoutValue(LayoutSchema.Empty, Variable.Empty, Macro.Empty);

        public LayoutSchema Schema { get; }

        public Variable ContentValue { get; }

        public Macro Macro { get; }


        public LayoutValue(LayoutSchema schema, Variable value, Macro macro)
        {
            Schema = schema;
            ContentValue = value;
            Macro = macro;
        }

    }
}
