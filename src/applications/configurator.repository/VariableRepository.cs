using Mov.Accessors;
using Mov.Configurator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Repository
{
    public class VariableRepository : DbObjectRepositoryBase<Variable, VariableCollection>, IVariableRepository
    {
        public VariableRepository(string path, string encoding = "utf-8") : base(path, encoding)
        {
        }
    }
}
