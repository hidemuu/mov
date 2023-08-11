namespace Mov.Core.Repositories.Models.Entities
{
    public class EntityObject<TKey>
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual TKey Id { get; set; }
    }
}
