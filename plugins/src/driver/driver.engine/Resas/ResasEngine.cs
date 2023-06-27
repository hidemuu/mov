using Mov.Driver.Clients.Resas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Engine.Resas
{
    public class ResasEngine : IResasEngine
    {
        private readonly IResasRepository _repository;

        public IResasCommand Command { get; }

        public IResasQuery Query { get; }

        public ResasEngine(IResasRepository repository)
        {
            _repository= repository;
        }
    }
}
