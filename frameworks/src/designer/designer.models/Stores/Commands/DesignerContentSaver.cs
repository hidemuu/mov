using Mov.Core.Stores;
using Mov.Designer.Models.Entities;
using System.Collections.Generic;

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

		public void Save(IEnumerable<DesignerContent> entities)
		{
			throw new System.NotImplementedException();
		}
	}
}
