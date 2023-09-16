namespace Mov.Core.Stores
{
    public interface IEventSubscriber
    {
        void Subscribe<T>(T @event) where T : IEvent;
    }
}
