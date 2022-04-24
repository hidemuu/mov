using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.WpfViewModels.Components.Tables
{
    public interface ITableViewModelColumnAttribute
    {
        public ColumnAttribute Id { get; }
        public ColumnAttribute Category { get; }
        public ColumnAttribute Code { get; }
        public ColumnAttribute Name { get; }
        public ColumnAttribute Description { get; }
    }
}
