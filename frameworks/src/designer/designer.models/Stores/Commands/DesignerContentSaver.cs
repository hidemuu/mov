using Mov.Core.Stores;
using Mov.Designer.Models.Entities;

namespace Mov.Designer.Models.Stores.Commands
{
    internal class DesignerContentSaver : ISave<DesignerContent>
    {
        private readonly IDesignerRepository _repository;

        public DesignerContentSaver(IDesignerRepository repository)
        {
            _repository = repository;
        }

        public void Save(DesignerContent entity)
        {
            //_repositorySaver.Save(entity);
        }
    }
}
