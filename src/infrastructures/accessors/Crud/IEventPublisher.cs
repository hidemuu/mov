using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Crud
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : IEvent;
    }
}
