﻿namespace Mov.Core.Characters.Personals.Builders
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