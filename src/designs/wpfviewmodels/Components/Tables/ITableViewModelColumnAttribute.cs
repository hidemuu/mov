using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.WpfViewModels.Components.Tables
{
    public interface ITableViewModelColumnAttribute
    {
        public TableColumnAttribute Id { get; }
        public TableColumnAttribute Category { get; }
        public TableColumnAttribute Code { get; }
        public TableColumnAttribute Name { get; }
        public TableColumnAttribute Description { get; }
    }
}
