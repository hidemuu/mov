using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : IEvent;
    }
}
