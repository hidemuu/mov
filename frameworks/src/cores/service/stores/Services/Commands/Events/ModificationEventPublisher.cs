using Mov.Core.Stores.Services.Commands.Deleters.Events;
using Mov.Core.Stores.Services.Commands.Savers.Events;
using System.Collections.Generic;
using System.Linq;

namespace Mov.Core.Stores.Services.Commands.Events
{
    public class ModificationEventPublisher<TEntity> : IDelete<TEntity>, ISave<TEntity>
    {
        #region field

        private readonly IDelete<TEntity> _deleter;
        private readonly ISave<TEntity> _saver;
        private readonly IEventPublisher _eventPublisher;

        #endregion field

        #region constructor

        public ModificationEventPublisher(IDelete<TEntity> deleter, ISave<TEntity> saver, IEventPublisher eventPublisher)
        {
            this._deleter = deleter;
            this._saver = saver;
            this._eventPublisher = eventPublisher;
        }

		#endregion constructor

		#region method

		public void Delete(TEntity entity)
        {
            _deleter.Delete(entity);
            var entityDeleted = new DeletedEvent<TEntity>(entity);
            _eventPublisher.Publish(entityDeleted);
        }



        public void Save(TEntity entity)
        {
            _saver.Save(entity);
            var entitySaved = new SavedEvent<TEntity>(entity);
            _eventPublisher.Publish(entitySaved);
        }

		public void Save(IEnumerable<TEntity> entities)
		{
			_saver.Save(entities);
			var entitySaved = new SavedEvent<TEntity>(entities.FirstOrDefault());
			_eventPublisher.Publish(entitySaved);
		}

		public void Clear()
		{
			_deleter.Clear();
		}

		#endregion method
	}
}