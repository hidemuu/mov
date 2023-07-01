namespace Mov.Core.Models.Entities.DbObjects
{
    public class EntityObject<TKey>
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual TKey Id { get; set; }
    }
}
