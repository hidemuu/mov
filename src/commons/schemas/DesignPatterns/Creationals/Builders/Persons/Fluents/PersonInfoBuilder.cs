using Mov.Schemas.Elements.Personals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.DesignPatterns.Creationals.Builders.Persons.Fluents
{
    public class PersonInfoBuilder<TSelf> : PersonBuilder
        where TSelf : PersonInfoBuilder<TSelf>
    {
        public TSelf Called(string name)
        {
            this.Name = new Name("", name);
            return (TSelf)this;
        }
    }
}
