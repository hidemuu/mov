﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface IEventSubscriber
    {
        void Subscribe<T>(T @event) where T : IEvent;
    }
}