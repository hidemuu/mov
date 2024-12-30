namespace Mov.Core.Stores.Services.Commands.Deleters.Events
{
    public class DeleteEventPublisher<TEntity> : IDelete<TEntity>
    {
        #region field

        private readonly IDelete<TEntity> _decoratedDelete;
        private readonly IEventPublisher _eventPublisher;

        #endregion field

        #region constructor

        public DeleteEventPublisher(IDelete<TEntity> decoratedDelete, IEventPublisher eventPublisher)
        {
            this._decoratedDelete = decoratedDelete; ;
            this._eventPublisher = eventPublisher;
        }

		#endregion constructor

		#region method

		public void Delete(TEntity entity)
        {
            _decoratedDelete.Delete(entity);
            var entityDeleted = new DeletedEvent<TEntity>(entity);
            _eventPublisher.Publish(entityDeleted);
        }

		public void Clear()
		{
			_decoratedDelete.Clear();
		}

		#endregion method
	}
}
