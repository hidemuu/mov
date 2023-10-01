using Mov.Core.Stores;
using Mov.Designer.Models.Entities;

namespace Mov.Designer.Models.Stores.Commands
{
    internal class DesignerContentDeleter : IDelete<DesignerContent>
    {
        private readonly IDesignerRepository _repository;

        public DesignerContentDeleter(IDesignerRepository repository)
        {
            _repository = repository;
        }

        public void Delete(DesignerContent entity)
        {
            //_repositoryDeleter.Delete(entity);
        }
    }
}
