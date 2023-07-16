namespace Mov.Core.Models.DbObjects.Entities
{
    public class EntityObject<TKey>
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual TKey Id { get; set; }
    }
}
