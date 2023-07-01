namespace Mov.Core.Models.Entities.Personals
{
    public sealed class Employment
    {
        public string CompanyName { get; }

        public string Position { get; }

        public Employment(string companyName, string position)
        {
            CompanyName = companyName;
            Position = position;
        }

    }
}
