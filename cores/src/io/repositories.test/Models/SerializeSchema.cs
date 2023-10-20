namespace Mov.Core.Repositories.Test.Models
{
    public class SerializeSchema : IDbSchema<int>
    {
        public int Id { get; set; } = 0;

        public string Content { get; set; } = string.Empty;

		public bool IsEmpty()
		{
			return Id.Equals(0);
		}
	}
}
