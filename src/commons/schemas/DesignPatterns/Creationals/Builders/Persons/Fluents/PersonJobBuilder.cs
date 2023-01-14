using Mov.Schemas.Elements;
using Mov.Schemas.Elements.Personals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.DesignPatterns.Creationals.Builders.Persons.Fluents
{
    public class PersonJobBuilder<TSelf> : PersonInfoBuilder<PersonJobBuilder<TSelf>>
        where TSelf : PersonJobBuilder<TSelf>
    {
        public TSelf WorksAsA(string position)
        {
            this.Employment = new Employment("", position);
            return (TSelf)this;
        }
    }
}
