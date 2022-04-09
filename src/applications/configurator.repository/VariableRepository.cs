using Mov.Accessors;
using Mov.Configurator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Repository
{
    public class VariableRepository : FileAccessor<Variable>, IVariableRepository
    {
        public readonly static string FILE_NAME = "variable";
        public VariableRepository(IFileHelper fileHelper) : base(fileHelper)
        {
        }
    }
}
