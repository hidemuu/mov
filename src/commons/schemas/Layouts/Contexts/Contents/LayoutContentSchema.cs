using Mov.Schemas.Implements.Bodies;
using Mov.Schemas.Parameters;
using Mov.Schemas.Parameters.Macros;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contexts.Contents
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
            this.Schema = schema;
            this.Variable = variable;
            this.Macro = macro;
        }

    }
}
