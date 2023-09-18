namespace Mov.Core.Stores
{
    public interface IEventPublisher
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
