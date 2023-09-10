namespace Mov.Core.Repositories.Test.Models
{
    public class SerializeSchema : IDbObject<int>
    {
        public int Id { get; set; } = 0;

        public string Content { get; set; } = string.Empty;
    }
}
