using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Configurator.Models
{
    public class Variable : DbObject
    {
        
        /// <summary>
        /// 読出/書込 (R:読出専用 W:書込専用 それ以外:読書可能
        /// </summary>
        [DisplayName("読み書き")]
        public string RW { get; set; }
    }
}
