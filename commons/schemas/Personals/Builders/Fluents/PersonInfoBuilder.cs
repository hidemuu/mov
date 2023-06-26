using Mov.Schemas.Personals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Personals.Builders.Fluents
{
    public class PersonInfoBuilder<TSelf> : PersonBuilder
        where TSelf : PersonInfoBuilder<TSelf>
    {
        public TSelf Called(string name)
        {
            Name = new Name("", name);
            return (TSelf)this;
        }
    }
}
