using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public class EntityObject<TKey>
    {
        /// <summary>
        /// ID
        /// </summary>
        public TKey Id { get; set; }
    }
}
