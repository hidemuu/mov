using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Personals.Builders.Functionals
{
    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorksAsA
      (this PersonBuilder builder, string position)
        {
            builder.Do(p =>
            {
                p.ChangePosition(position);
            });
            return builder;
        }
    }
}
