using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Templates.Events
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : IEvent;
    }
}
