using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : IEvent;
    }
}
