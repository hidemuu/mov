﻿using Mov.Core.Models.Entities.Personals.Builders.Functionals;

namespace Mov.Core.Models.Entities.Personals.Persons.Functionals
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