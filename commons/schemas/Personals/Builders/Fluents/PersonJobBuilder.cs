using Mov.Schemas.Personals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Personals.Builders.Fluents
{
    public class PersonJobBuilder<TSelf> : PersonInfoBuilder<PersonJobBuilder<TSelf>>
        where TSelf : PersonJobBuilder<TSelf>
    {
        public TSelf WorksAsA(string position)
        {
            Employment = new Employment("", position);
            return (TSelf)this;
        }
    }
}
