using Mov.Utilities.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Models.Entities.Contents
{
    public class LayoutContentSchema
    {
        public static LayoutContentSchema Empty = new LayoutContentSchema(
            LayoutSchema.Empty, Variable.Empty, Macro.Empty);

        public LayoutSchema Schema { get; }

        public Variable Variable { get; }

        public Macro Macro { get; }


        public LayoutContentSchema(LayoutSchema schema, Variable variable, Macro macro)
        {
            Schema = schema;
            Variable = variable;
            Macro = macro;
        }

    }
}
