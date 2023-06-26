using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Templates.Events
{
    public interface IEventSubscriber
    {
        void Subscribe<T>(T @event) where T : IEvent;
    }
}
