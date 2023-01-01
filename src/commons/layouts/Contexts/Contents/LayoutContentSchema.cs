using Mov.Schemas.Bodies;
using Mov.Schemas.Parameters;
using Mov.Schemas.Resources.Macros;
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

        public Variable ContentValue { get; }

        public Macro Macro { get; }


        public LayoutContentSchema(LayoutSchema schema, Variable value, Macro macro)
        {
            Schema = schema;
            ContentValue = value;
            Macro = macro;
        }

    }
}
