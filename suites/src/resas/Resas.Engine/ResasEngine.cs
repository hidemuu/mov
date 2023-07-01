using Mov.Suite.Resas.Models;

namespace Mov.Suite.Resas.Engine
{
    public class ResasEngine : IResasEngine
    {
        private readonly IResasRepository _repository;

        public IResasCommand Command { get; }

        public IResasQuery Query { get; }

        public ResasEngine(IResasRepository repository)
        {
            _repository = repository;
        }
    }
}
