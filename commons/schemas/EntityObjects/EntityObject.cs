using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.EntityObject
{
    public class EntityObject<TKey>
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual TKey Id { get; set; }
    }
}
