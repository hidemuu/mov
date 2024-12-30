using System;

namespace Mov.Core.Models
{
    public class Relationship : ValueObjectBase<Relationship>
    {
        public static Relationship Parent = new Relationship("Parent");

        public static Relationship Child = new Relationship("Child");

        public string Value { get; }

        public Relationship(string value)
        {
        }

        protected override bool EqualCore(Relationship other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
