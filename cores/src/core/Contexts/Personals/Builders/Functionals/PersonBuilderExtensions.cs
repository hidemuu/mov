namespace Mov.Core.Contexts.Personals.Builders.Functionals
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
