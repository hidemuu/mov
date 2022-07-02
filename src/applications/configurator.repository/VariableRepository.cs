using Mov.Accessors;
using Mov.Configurator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Repository
{
    public class VariableRepository : DbObjectRepository<Variable, VariableCollection>, IVariableRepository
    {
        public VariableRepository(string path, string encoding = DbConstants.ENCODE_NAME_UTF8) : base(path, encoding)
        {
        }
    }
}
